USE dummy_api_db;
GO

--INSERT INTO [HeadOfDepartment] ([DepartmentID], [UniversityID], [UserID])
--VALUES 
--(1, 7, 28),
--(2, 12, 19),
--(3, 1, 45),
--(1, 15, 51),
--(2, 9, 32),
--(3, 4, 24),
--(1, 5, 39),
--(2, 10, 14),
--(3, 6, 7),
--(1, 11, 21),
--(2, 8, 47),
--(3, 2, 36),
--(1, 13, 5),
--(2, 3, 49),
--(3, 14, 17);

DECLARE @CurrentDate DATE = GETDATE();

INSERT INTO [StudentBursaryApplication] ([ApplicationMotivation], [StudentID], [ApplicationRejectionReason], [StatusID], [AverageMark], [BursaryAmount], [BursaryDetailsID], [HeadOfDepartmentID], [ApplicationDate])
VALUES
('Student has demonstrated exceptional dedication to their studies and consistently achieves high grades.', 1, 'N/A', 1, 85, 25000.00, 2024, 5, DATEADD(day, -20, @CurrentDate)),
('Student actively contributes to the academic community and exhibits strong leadership skills.', 2, 'N/A', 2, 92, 35000.00, 2024, 9, DATEADD(day, -15, @CurrentDate)),
('Despite facing challenges, student maintains remarkable academic performance and displays strong commitment to learning.', 3, 'N/A', 1, 88, 30000.00, 2024, 12, DATEADD(day, -10, @CurrentDate)),
('Although student''s academic performance is satisfactory, other applicants demonstrated greater need for bursary.', 4, 'Bursary funds were allocated to applicants with higher financial need.', 3, 78, 15000.00, 2024, 7, DATEADD(day, -5, @CurrentDate)),
('Student exhibits outstanding academic achievements and actively engages in extracurricular activities.', 5, 'N/A', 2, 95, 40000.00, 2024, 11, DATEADD(day, -8, @CurrentDate)),
('Student consistently demonstrates perseverance and dedication to their studies, deserving of financial support.', 6, 'N/A', 1, 87, 28000.00, 2024, 14, DATEADD(day, -12, @CurrentDate)),
('Despite facing adversity, student maintains exceptional academic performance and contributes positively to the academic environment.', 7, 'N/A', 2, 90, 32000.00, 2024, 3, DATEADD(day, -18, @CurrentDate)),
('While student shows promise, bursary funds were allocated to applicants with more urgent financial need.', 8, 'Bursary funds were prioritized for applicants with urgent financial circumstances.', 3, 75, 18000.00, 2024, 8, DATEADD(day, -22, @CurrentDate)),
('Student''s commitment to education and perseverance despite challenges makes them deserving of support.', 9, 'N/A', 1, 89, 29000.00, 2024, 10, DATEADD(day, -25, @CurrentDate)),
('Student actively seeks opportunities for growth and demonstrates practical skills in their field of study.', 10, 'N/A', 2, 93, 37000.00, 2024, 13, DATEADD(day, -28, @CurrentDate)),
('Student consistently maintains high academic performance and shows dedication to their studies.', 11, 'N/A', 1, 86, 26000.00, 2024, 6, DATEADD(day, -30, @CurrentDate)),
('While student has shown potential, other applicants demonstrated greater financial need.', 12, 'Bursary funds were allocated to applicants with more pressing financial circumstances.', 3, 70, 12000.00, 2024, 2, DATEADD(day, -35, @CurrentDate)),
('Despite facing challenges, student maintains strong academic performance and contributes positively to the academic community.', 13, 'N/A', 1, 88, 31000.00, 2024, 15, DATEADD(day, -40, @CurrentDate)),
('Student actively seeks mentorship and academic support to enhance their learning experience.', 14, 'N/A', 2, 94, 38000.00, 2024, 4, DATEADD(day, -45, @CurrentDate)),
('Student''s dedication to their field of study is evident through their academic achievements and participation in research projects.', 15, 'N/A', 3, 72, 11000.00, 2024, 1, DATEADD(day, -50, @CurrentDate)),
('Despite facing personal challenges, student remains focused on their studies and seeks opportunities for growth.', 16, 'N/A', 1, 85, 27000.00, 2024, 5, DATEADD(day, -55, @CurrentDate)),
('Student actively pursues opportunities for professional development and career advancement.', 17, 'N/A', 2, 91, 33000.00, 2024, 9, DATEADD(day, -60, @CurrentDate)),
('While student shows promise, bursary funds were allocated to applicants with more urgent financial needs.', 18, 'Bursary funds were prioritized for applicants with urgent financial circumstances.', 3, 74, 13000.00, 2024, 12, DATEADD(day, -65, @CurrentDate)),
('Student demonstrates strong work ethic and commitment to excellence in their academic endeavors.', 19, 'N/A', 1, 87, 28000.00, 2024, 7, DATEADD(day, -70, @CurrentDate)),
('Despite facing obstacles, student remains dedicated to their studies and seeks opportunities for growth.', 20, 'N/A', 2, 92, 36000.00, 2024, 11, DATEADD(day, -75, @CurrentDate)),
('Student''s passion for their field of study drives them to excel academically and pursue opportunities for research.', 21, 'N/A', 1, 86, 26000.00, 2024, 14, DATEADD(day, -80, @CurrentDate)),
('Student actively engages in hands-on learning experiences and internships to gain practical skills.', 22, 'N/A', 3, 76, 14000.00, 2024, 3, DATEADD(day, -85, @CurrentDate)),
('Despite facing challenges, student remains committed to their education and maintains strong academic performance.', 23, 'N/A', 1, 88, 30000.00, 2024, 8, DATEADD(day, -90, @CurrentDate)),
('Student demonstrates leadership qualities through involvement in student government and campus activities.', 24, 'N/A', 2, 93, 37000.00, 2024, 10, DATEADD(day, -95, @CurrentDate)),
('Student''s dedication to their studies is evident through their academic achievements and active participation in class.', 25, 'N/A', 1, 85, 27000.00, 2024, 13, DATEADD(day, -100, @CurrentDate)),
('Student actively seeks mentorship and guidance to support their academic and professional development.', 26, 'N/A', 3, 77, 15000.00, 2024, 6, DATEADD(day, -105, @CurrentDate)),
('Despite facing financial challenges, student maintains strong academic performance and contributes to campus life.', 27, 'N/A', 1, 89, 31000.00, 2024, 15, DATEADD(day, -110, @CurrentDate)),
('Student actively pursues research opportunities and independent study projects to deepen their understanding.', 28, 'N/A', 2, 94, 38000.00, 2024, 4, DATEADD(day, -115, @CurrentDate)),
('Student''s dedication to their education is evident through their academic achievements and commitment to learning.', 29, 'N/A', 1, 86, 26000.00, 2024, 1, DATEADD(day, -120, @CurrentDate)),
('Student actively participates in academic conferences and seminars to expand their knowledge and network with professionals.', 30, 'N/A', 3, 78, 16000.00, 2024, 5, DATEADD(day, -125, @CurrentDate)),
('Despite facing personal challenges, student remains focused on their studies and seeks opportunities for growth.', 31, 'N/A', 1, 88, 30000.00, 2024, 9, DATEADD(day, -130, @CurrentDate)),
('Student demonstrates leadership qualities through involvement in student organizations and community initiatives.', 32, 'N/A', 2, 93, 37000.00, 2024, 12, DATEADD(day, -135, @CurrentDate)),
('Student''s passion for their field of study drives them to excel academically and pursue opportunities for research.', 33, 'N/A', 1, 87, 28000.00, 2024, 7, DATEADD(day, -140, @CurrentDate)),
('Student actively engages in hands-on learning experiences and internships to gain practical skills.', 34, 'N/A', 3, 79, 17000.00, 2024, 11, DATEADD(day, -145, @CurrentDate)),
('Despite facing challenges, student remains committed to their education and maintains strong academic performance.', 35, 'Student did not meet the minimum eligibility criteria for the bursary.', 3, 80, 125000.00, 2024, 14, DATEADD(day, -150, @CurrentDate));
