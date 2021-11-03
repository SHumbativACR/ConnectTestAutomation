Feature: ImportPXSFile
	Verifying if user is able to import PXS dataset to Data Manager service

@SmokeTest
@test-ImportPXSFileTest
Scenario: Verify that user can import PXS data by using the DICOM service
	Given User navigates to DICOM Import data & annotations page and imports PXS studies
	When User navigates to Data Manager service and searches for the imported dataset
	Then Newly imported dataset is displayed successfully and study count is as expected