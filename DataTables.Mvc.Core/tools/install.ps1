param($installPath, $toolsPath, $package, $project)

$path = [System.IO.Path]
$appstart = $path::Combine($path::GetDirectoryName($project.FileName), "App_Start\DataTablesMvc.cs")
$models = $path::Combine($path::GetDirectoryName($project.FileName), "Models\DataTablesParams.cs")
$DTE.ItemOperations.OpenFile($appstart)