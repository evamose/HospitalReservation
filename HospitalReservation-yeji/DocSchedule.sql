-- 새 테이블 정의
CREATE TABLE WORK_SCHEDULE (
  WORK_SCHED_ID NUMBER       PRIMARY KEY,
  DOCTOR_ID     NUMBER       NOT NULL,
  WORK_DATE     DATE         NOT NULL,
  WORK_STATUS   VARCHAR2(10) NOT NULL,
  WORK_TIME     VARCHAR2(50)
);

ALTER TABLE WORK_SCHEDULE
  ADD CONSTRAINT FK_WORK_SCHEDULE_DOCTOR
  FOREIGN KEY (DOCTOR_ID)
  REFERENCES DOCTOR(DOCTOR_ID);

COMMIT;

-------------------------------------------------------------
-- WORK_SCHEDULE 테스트 데이터 (도메인 기반)
-- 2025년 12월 1일 ~ 10일
-------------------------------------------------------------

-- 기존 데이터 삭제
DELETE FROM WORK_SCHEDULE;
COMMIT;

-------------------------------------------------------------
-- 2025-12-01
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (1, 1, DATE '2025-12-01', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (2, 2, DATE '2025-12-01', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (3, 3, DATE '2025-12-01', 'WORK', 'Evening');

-------------------------------------------------------------
-- 2025-12-02
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (4, 1, DATE '2025-12-02', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (5, 2, DATE '2025-12-02', 'WORK', 'Evening');
INSERT INTO WORK_SCHEDULE VALUES (6, 3, DATE '2025-12-02', 'OFF',  NULL);

-------------------------------------------------------------
-- 2025-12-03
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (7, 1, DATE '2025-12-03', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (8, 3, DATE '2025-12-03', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (9, 2, DATE '2025-12-03', 'OFF',  NULL);

-------------------------------------------------------------
-- 2025-12-04
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (10, 1, DATE '2025-12-04', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (11, 2, DATE '2025-12-04', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (12, 3, DATE '2025-12-04', 'WORK', 'Evening');
INSERT INTO WORK_SCHEDULE VALUES (13, 4, DATE '2025-12-04', 'WORK', 'Morning');

-------------------------------------------------------------
-- 2025-12-05
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (14, 1, DATE '2025-12-05', 'OFF',  NULL);
INSERT INTO WORK_SCHEDULE VALUES (15, 2, DATE '2025-12-05', 'OFF',  NULL);
INSERT INTO WORK_SCHEDULE VALUES (16, 3, DATE '2025-12-05', 'OFF',  NULL);
INSERT INTO WORK_SCHEDULE VALUES (17, 5, DATE '2025-12-05', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (18, 6, DATE '2025-12-05', 'WORK', 'Evening');

-------------------------------------------------------------
-- 2025-12-06
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (19, 1, DATE '2025-12-06', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (20, 2, DATE '2025-12-06', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (21, 3, DATE '2025-12-06', 'WORK', 'Evening');

-------------------------------------------------------------
-- 2025-12-07
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (22, 7, DATE '2025-12-07', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (23, 8, DATE '2025-12-07', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (24, 9, DATE '2025-12-07', 'WORK', 'Evening');

-------------------------------------------------------------
-- 2025-12-08
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (25, 1,  DATE '2025-12-08', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (26, 2,  DATE '2025-12-08', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (27, 3,  DATE '2025-12-08', 'WORK', 'Evening');
INSERT INTO WORK_SCHEDULE VALUES (28, 10, DATE '2025-12-08', 'WORK', 'Morning');

-------------------------------------------------------------
-- 2025-12-09
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (29, 1, DATE '2025-12-09', 'OFF',  NULL);
INSERT INTO WORK_SCHEDULE VALUES (30, 2, DATE '2025-12-09', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (31, 3, DATE '2025-12-09', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (32, 4, DATE '2025-12-09', 'OFF',  NULL);
INSERT INTO WORK_SCHEDULE VALUES (33, 5, DATE '2025-12-09', 'WORK', 'Evening');

-------------------------------------------------------------
-- 2025-12-10
-------------------------------------------------------------
INSERT INTO WORK_SCHEDULE VALUES (34, 1,  DATE '2025-12-10', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (35, 2,  DATE '2025-12-10', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (36, 3,  DATE '2025-12-10', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (37, 4,  DATE '2025-12-10', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (38, 5,  DATE '2025-12-10', 'WORK', 'Evening');
INSERT INTO WORK_SCHEDULE VALUES (39, 6,  DATE '2025-12-10', 'WORK', 'Evening');
INSERT INTO WORK_SCHEDULE VALUES (40, 7,  DATE '2025-12-10', 'OFF',  NULL);
INSERT INTO WORK_SCHEDULE VALUES (41, 8,  DATE '2025-12-10', 'WORK', 'Morning');
INSERT INTO WORK_SCHEDULE VALUES (42, 9,  DATE '2025-12-10', 'WORK', 'Afternoon');
INSERT INTO WORK_SCHEDULE VALUES (43, 10, DATE '2025-12-10', 'WORK', 'Evening');

COMMIT;


