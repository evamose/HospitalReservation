------------------------------------------------------------
--  HOSPITAL 프로젝트 DB 스키마 + 테스트 데이터
--  계정: HOSPITAL_USER / 1234
------------------------------------------------------------

------------------------------------------------------------
-- 0. 기존 사용자/HOSPITAL_USER 삭제 (SYS/SYSTEM 계정에서 실행)
------------------------------------------------------------
BEGIN
    EXECUTE IMMEDIATE 'DROP USER HOSPITAL_USER CASCADE';
EXCEPTION
    WHEN OTHERS THEN
        -- ORA-01918: user 'HOSPITAL_USER' does not exist
        IF SQLCODE != -1918 THEN
            RAISE;
        END IF;
END;
/
------------------------------------------------------------
-- 1. HOSPITAL_USER 계정 생성 및 권한 부여
------------------------------------------------------------
CREATE USER HOSPITAL_USER IDENTIFIED BY 1234
    DEFAULT TABLESPACE USERS
    TEMPORARY TABLESPACE TEMP
    QUOTA UNLIMITED ON USERS;

GRANT CONNECT, RESOURCE TO HOSPITAL_USER;
ALTER USER HOSPITAL_USER ACCOUNT UNLOCK;

------------------------------------------------------------
-- 2. HOSPITAL_USER 로 접속
------------------------------------------------------------
CONNECT HOSPITAL_USER/1234

------------------------------------------------------------
-- 3. 기존 테이블 DROP (있다면 삭제)
--    FK 관계 때문에 자식 → 부모 순서로 삭제
------------------------------------------------------------
BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE PRESCRIPTION PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE VISIT PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE PATIENT PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE DOCTOR PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE DRUG PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE MEDICAL_DEPT PURGE';
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

------------------------------------------------------------
-- 4. 테이블 생성
------------------------------------------------------------

-----------------------------
-- 4-1. 진료과 테이블 (MEDICAL_DEPT)
-----------------------------
CREATE TABLE MEDICAL_DEPT (
    DEPT_ID      NUMBER       PRIMARY KEY,
    DEPT_NAME    VARCHAR2(100) NOT NULL,
    DESCRIPTION  VARCHAR2(500)
);

-----------------------------
-- 4-2. 약품 테이블 (DRUG)
-----------------------------
CREATE TABLE DRUG (
    DRUG_ID      NUMBER        PRIMARY KEY,
    DRUG_NAME    VARCHAR2(200) NOT NULL,
    FORM         VARCHAR2(50),     -- 정제, 캡슐, 시럽 등
    UNIT         VARCHAR2(50),     -- mg, ml, 정 등
    DESCRIPTION  VARCHAR2(500)
);

-----------------------------
-- 4-3. 의사 테이블 (DOCTOR)
-----------------------------
CREATE TABLE DOCTOR (
    DOCTOR_ID   NUMBER        PRIMARY KEY,
    NAME        VARCHAR2(50)  NOT NULL,
    BIRTH       DATE          NOT NULL,
    PHONE       VARCHAR2(20)  NOT NULL,
    EMAIL       VARCHAR2(100),
    ADDRESS     VARCHAR2(200),
    LICENSE_NO  VARCHAR2(50),
    DEPT        VARCHAR2(50),      -- 진료과 이름(문자열, MEDICAL_DEPT.DEPT_NAME와 논리적 연계)
    ROOM        VARCHAR2(20),
    NOTE        VARCHAR2(500)
);

-----------------------------
-- 4-4. 환자 테이블 (PATIENT)
-----------------------------
CREATE TABLE PATIENT (
    PATIENT_ID    NUMBER        PRIMARY KEY,
    NAME          VARCHAR2(50)  NOT NULL,
    BIRTH         DATE          NOT NULL,
    GENDER        VARCHAR2(10)  NOT NULL,
    PHONE         VARCHAR2(20)  NOT NULL,
    ADDRESS       VARCHAR2(200) NOT NULL,
    VISIT_REASON  VARCHAR2(200),
    DOCTOR_NO     NUMBER,                           -- 담당의 (DOCTOR.DOCTOR_ID)
    CONSTRAINT FK_PATIENT_DOCTOR
        FOREIGN KEY (DOCTOR_NO)
        REFERENCES DOCTOR(DOCTOR_ID)
);

-----------------------------
-- 4-5. 진료 테이블 (VISIT)
-----------------------------
CREATE TABLE VISIT (
    VISIT_ID      NUMBER        PRIMARY KEY,
    PATIENT_ID    NUMBER        NOT NULL,
    DOCTOR_ID     NUMBER        NOT NULL,
    VISIT_DATE    DATE          NOT NULL,
    DEPT          VARCHAR2(50),       -- 진료과 이름
    SYMPTOM       VARCHAR2(500),      -- 증상
    DISEASE_CODE  VARCHAR2(50),       -- 질병 코드
    DIAGNOSIS     VARCHAR2(1000),     -- 진단 내용
    CONSTRAINT FK_VISIT_PATIENT
        FOREIGN KEY (PATIENT_ID)
        REFERENCES PATIENT(PATIENT_ID),
    CONSTRAINT FK_VISIT_DOCTOR
        FOREIGN KEY (DOCTOR_ID)
        REFERENCES DOCTOR(DOCTOR_ID)
);

-----------------------------
-- 4-6. 처방 테이블 (PRESCRIPTION)
-----------------------------
CREATE TABLE PRESCRIPTION (
    PRESC_ID       NUMBER        PRIMARY KEY,
    PATIENT_ID     NUMBER        NOT NULL,
    DOCTOR_ID      NUMBER        NOT NULL,
    VISIT_ID       NUMBER,
    PRESC_DATE     DATE          NOT NULL,
    DRUG_NAME      VARCHAR2(200) NOT NULL,  -- DRUG.DRUG_NAME과 논리적 연계
    DOSAGE         VARCHAR2(100),           -- 500mg 등
    TIMES_PER_DAY  NUMBER,                  -- 1일 투여 횟수
    DAYS           NUMBER,                  -- 투여 일수
    METHOD         VARCHAR2(200),           -- 경구, 점안, 외용 등
    CONSTRAINT FK_PRESC_PATIENT
        FOREIGN KEY (PATIENT_ID)
        REFERENCES PATIENT(PATIENT_ID),
    CONSTRAINT FK_PRESC_DOCTOR
        FOREIGN KEY (DOCTOR_ID)
        REFERENCES DOCTOR(DOCTOR_ID),
    CONSTRAINT FK_PRESC_VISIT
        FOREIGN KEY (VISIT_ID)
        REFERENCES VISIT(VISIT_ID)
);

------------------------------------------------------------
-- 5. 테스트 데이터 INSERT
------------------------------------------------------------

-----------------------------
-- 5-1. 진료과 (MEDICAL_DEPT)
-----------------------------
INSERT INTO MEDICAL_DEPT (DEPT_ID, DEPT_NAME, DESCRIPTION) VALUES (1, '내과', '호흡기, 소화기, 순환기 등 내과질환 진료');
INSERT INTO MEDICAL_DEPT (DEPT_ID, DEPT_NAME, DESCRIPTION) VALUES (2, '정형외과', '뼈, 관절, 근육 관련 진료');
INSERT INTO MEDICAL_DEPT (DEPT_ID, DEPT_NAME, DESCRIPTION) VALUES (3, '소아과', '소아 및 청소년 질환 진료');
INSERT INTO MEDICAL_DEPT (DEPT_ID, DEPT_NAME, DESCRIPTION) VALUES (4, '산부인과', '임신, 출산 및 여성질환 진료');
INSERT INTO MEDICAL_DEPT (DEPT_ID, DEPT_NAME, DESCRIPTION) VALUES (5, '피부과', '피부 및 미용 관련 진료');

-----------------------------
-- 5-2. 약품 (DRUG)
-----------------------------
INSERT INTO DRUG (DRUG_ID, DRUG_NAME, FORM, UNIT, DESCRIPTION)
VALUES (1, '타이레놀', '정제', '500mg', '해열, 진통제');

INSERT INTO DRUG (DRUG_ID, DRUG_NAME, FORM, UNIT, DESCRIPTION)
VALUES (2, '근육이완제', '정제', '10mg', '근육 긴장 완화');

INSERT INTO DRUG (DRUG_ID, DRUG_NAME, FORM, UNIT, DESCRIPTION)
VALUES (3, '항생제 시럽', '시럽', '10ml', '소아용 항생제');

INSERT INTO DRUG (DRUG_ID, DRUG_NAME, FORM, UNIT, DESCRIPTION)
VALUES (4, '스테로이드 크림', '연고', '?', '피부 염증 완화');

INSERT INTO DRUG (DRUG_ID, DRUG_NAME, FORM, UNIT, DESCRIPTION)
VALUES (5, '소화제', '정제', '1정', '소화불량 완화');

-----------------------------
-- 5-3. 의사 (DOCTOR) - 5명
-----------------------------
INSERT INTO DOCTOR (DOCTOR_ID, NAME, BIRTH, PHONE, EMAIL, ADDRESS, LICENSE_NO, DEPT, ROOM, NOTE)
VALUES (1, '김민준', DATE '1980-03-21', '010-1111-2222', 'minjun@hospital.com', '서울 강남구', 'LIC-001', '내과', '101', '내과 전문의');

INSERT INTO DOCTOR (DOCTOR_ID, NAME, BIRTH, PHONE, EMAIL, ADDRESS, LICENSE_NO, DEPT, ROOM, NOTE)
VALUES (2, '이서준', DATE '1975-07-11', '010-2222-3333', 'seojun@hospital.com', '서울 마포구', 'LIC-002', '정형외과', '202', NULL);

INSERT INTO DOCTOR (DOCTOR_ID, NAME, BIRTH, PHONE, EMAIL, ADDRESS, LICENSE_NO, DEPT, ROOM, NOTE)
VALUES (3, '박서연', DATE '1988-11-02', '010-3333-4444', 'seoyeon@hospital.com', '서울 송파구', 'LIC-003', '소아과', '303', NULL);

INSERT INTO DOCTOR (DOCTOR_ID, NAME, BIRTH, PHONE, EMAIL, ADDRESS, LICENSE_NO, DEPT, ROOM, NOTE)
VALUES (4, '최하늘', DATE '1983-12-18', '010-4444-5555', 'haneul@hospital.com', '서울 영등포구', 'LIC-004', '산부인과', '404', NULL);

INSERT INTO DOCTOR (DOCTOR_ID, NAME, BIRTH, PHONE, EMAIL, ADDRESS, LICENSE_NO, DEPT, ROOM, NOTE)
VALUES (5, '정우진', DATE '1990-05-09', '010-5555-6666', 'woojin@hospital.com', '서울 은평구', 'LIC-005', '피부과', '505', NULL);

-----------------------------
-- 5-4. 환자 (PATIENT) - 10명
-----------------------------
INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (1, '김가영', DATE '1995-02-14', '여', '010-9999-1111', '서울 강남구', '기침 지속', 1);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (2, '박진수', DATE '1988-06-09', '남', '010-8888-2222', '서울 마포구', '무릎 통증', 2);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (3, '이하린', DATE '2012-08-21', '여', '010-7777-3333', '서울 송파구', '감기', 3);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (4, '최영희', DATE '1990-03-17', '여', '010-6666-4444', '서울 강서구', '피부 트러블', 5);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (5, '정현우', DATE '2001-11-30', '남', '010-5555-6666', '서울 노원구', '두통', 1);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (6, '오준호', DATE '1983-04-12', '남', '010-4444-7777', '서울 중구', '허리 통증', 2);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (7, '윤서윤', DATE '2019-10-03', '여', '010-3333-8888', '서울 성북구', '열감', 3);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (8, '한지민', DATE '1998-12-25', '여', '010-2222-9999', '서울 종로구', '여성검진', 4);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (9, '서지훈', DATE '1994-01-07', '남', '010-1111-0000', '서울 도봉구', '여드름', 5);

INSERT INTO PATIENT (PATIENT_ID, NAME, BIRTH, GENDER, PHONE, ADDRESS, VISIT_REASON, DOCTOR_NO)
VALUES (10, '배수정', DATE '1982-09-15', '여', '010-1010-1010', '서울 금천구', '소화불량', 1);

-----------------------------
-- 5-5. 진료 (VISIT) - 10건
-----------------------------
INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (1, 1, 1, DATE '2025-01-02', '내과', '기침, 콧물', 'J00', '급성 감기');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (2, 2, 2, DATE '2025-01-03', '정형외과', '무릎 통증', 'M25', '관절 통증');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (3, 3, 3, DATE '2025-01-04', '소아과', '열, 기침', 'J06', '상기도 감염');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (4, 4, 5, DATE '2025-01-05', '피부과', '여드름 악화', 'L70', '여드름');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (5, 5, 1, DATE '2025-01-06', '내과', '두통', 'R51', '두통');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (6, 6, 2, DATE '2025-01-07', '정형외과', '허리 통증', 'M54', '요통');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (7, 7, 3, DATE '2025-01-08', '소아과', '고열', 'J18', '폐렴 의심');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (8, 8, 4, DATE '2025-01-09', '산부인과', '정기검진', 'Z01', '여성 검진');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (9, 9, 5, DATE '2025-01-10', '피부과', '피부 발진', 'L71', '피부염');

INSERT INTO VISIT (VISIT_ID, PATIENT_ID, DOCTOR_ID, VISIT_DATE, DEPT, SYMPTOM, DISEASE_CODE, DIAGNOSIS)
VALUES (10, 10, 1, DATE '2025-01-11', '내과', '소화불량', 'K30', '소화불량');

-----------------------------
-- 5-6. 처방 (PRESCRIPTION) - 10건
-----------------------------
INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (1, 1, 1, 1, DATE '2025-01-02', '타이레놀', '500mg', 3, 3, '경구');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (2, 2, 2, 2, DATE '2025-01-03', '근육이완제', '10mg', 2, 5, '경구');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (3, 3, 3, 3, DATE '2025-01-04', '항생제 시럽', '10ml', 2, 5, '경구');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (4, 4, 5, 4, DATE '2025-01-05', '스테로이드 크림', '도포', NULL, 7, '외용');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (5, 5, 1, 5, DATE '2025-01-06', '타이레놀', '500mg', 2, 2, '경구');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (6, 6, 2, 6, DATE '2025-01-07', '근육이완제', '10mg', 2, 3, '경구');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (7, 7, 3, 7, DATE '2025-01-08', '항생제 시럽', '10ml', 3, 7, '경구');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (8, 8, 4, 8, DATE '2025-01-09', '소화제', '1정', 1, 3, '경구');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (9, 9, 5, 9, DATE '2025-01-10', '스테로이드 크림', '도포', NULL, 5, '외용');

INSERT INTO PRESCRIPTION (PRESC_ID, PATIENT_ID, DOCTOR_ID, VISIT_ID, PRESC_DATE, DRUG_NAME, DOSAGE, TIMES_PER_DAY, DAYS, METHOD)
VALUES (10, 10, 1, 10, DATE '2025-01-11', '소화제', '1정', 3, 2, '경구');

------------------------------------------------------------
COMMIT;
------------------------------------------------------------
