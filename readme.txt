Если возникает ошибка:
Не удалось найти часть пути "C:\Users\A_Zhanbulatov\Desktop\KZGR\KZGR_OnlineLendingAgroSector-kzgr\KZGR_OnlineLendingAgroSector\bin\roslyn\csc.exe".
	ADD to .csproj:  http://qaru.site/questions/38271/could-not-find-a-part-of-the-path-binroslyncscexe
	<Target Name="CopyRoslynFiles" AfterTargets="AfterBuild" Condition="!$(Disable_CopyWebApplication) And '$(OutDir)' != '$(OutputPath)'">
    <ItemGroup>
      <RoslynFiles Include="$(CscToolPath)\*" />
    </ItemGroup>
    <MakeDir Directories="$(WebProjectOutputDir)\bin\roslyn" />
    <Copy SourceFiles="@(RoslynFiles)" DestinationFolder="$(WebProjectOutputDir)\bin\roslyn" SkipUnchangedFiles="true" Retries="$(CopyRetryCount)" RetryDelayMilliseconds="$(CopyRetryDelayMilliseconds)" />
</Target>