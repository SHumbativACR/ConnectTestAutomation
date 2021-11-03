Feature: ImportBDFile
	Verifying if user is able to import Breast Density dataset to Data Manager service

@SmokeTest
@test-ImportBDFileTest
Scenario: Verify that user can import BD data by using the DICOM service
	Given User navigates to DICOM Import data & annotations page
	And User imports excel file that contains Breast Density studies
	When User navigates to Data Manager service and searches for the dataset
	Then Newly imported dataset is displayed successfully