
@set "branch=%1"

@IF .%branch% == . (
	@set "branch=dev.current"
)

@set "msbuildpath="C:\Program Files (x86)\msbuild\12.0\Bin\msbuild.exe""
@set "params=/nologo /t:Rebuild;Publish /verbosity:quiet /consoleloggerparameters:NoSummary;ErrorsOnly"
@set "xmlfolder=%CD%\Localhost"
@set "projectsfolder=C:\Dev\main\branches\%branch%\databases"

@echo Using %branch%

@echo Publishing Accounting
@%msbuildpath% %params% /p:SqlPublishProfilePath="%xmlfolder%\Accounting.publish.xml" "%projectsfolder%\Accounting\Accounting.sqlproj"

@echo Publishing Admin
@%msbuildpath% %params% /p:SqlPublishProfilePath="%xmlfolder%\Admin.publish.xml" "%projectsfolder%\Admin\Admin.sqlproj"

@echo Publishing Agency
@%msbuildpath% %params% /p:SqlPublishProfilePath="%xmlfolder%\Agency.publish.xml" "%projectsfolder%\Agency\Agency.sqlproj"

@echo Publishing ComplianceReview
@%msbuildpath% %params% /p:SqlPublishProfilePath="%xmlfolder%\ComplianceReview.publish.xml" "%projectsfolder%\Compliance\ComplianceReview.sqlproj"

@echo Publishing FundDesignation
@%msbuildpath% %params% /p:SqlPublishProfilePath="%xmlfolder%\FundDesignation.publish.xml" "%projectsfolder%\FundDesignation\FundDesignation.sqlproj"

@echo Publishing LossProcessing
@%msbuildpath% %params% /p:SqlPublishProfilePath="%xmlfolder%\LossProcessing.publish.xml" "%projectsfolder%\Loss\LossProcessing.sqlproj"

@echo Publishing PolicyManagement
@%msbuildpath% %params% /p:SqlPublishProfilePath="%xmlfolder%\PolicyManagement.publish.xml" "%projectsfolder%\Policy\PolicyManagement.sqlproj"


@echo Complete

pause