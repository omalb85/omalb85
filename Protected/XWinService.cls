<?xml version="1.0" encoding="utf-16"?>
<AgileDotNet Version="6.6.0.12">
  <AssemblyList>
    <Assembly Path="..\XWinService\bin\Release\AIEncryptor.dll" Secure="false" Obfuscation="false" FlowObfuscation="false" MethodCallObfuscation="false" ILMerge="secondary" />
    <Assembly Path="..\XWinService\bin\Release\Newtonsoft.Json.dll" Secure="false" Obfuscation="false" FlowObfuscation="false" MethodCallObfuscation="false" ILMerge="none" />
    <Assembly Path="..\XWinService\bin\Release\XWinService.exe" Secure="true" Obfuscation="true" FlowObfuscation="true" MethodCallObfuscation="true" ILMerge="primary" />
  </AssemblyList>
  <Settings>
    <General OutputDirectory="Final Out" SignatureFile="" PfxPassword="" FilePathMode="relativepath" GenerateDebugInfo="True" SdkPath="" />
    <Obfuscation ObfuscationMapFile="ObfuscationMap" RenamingScheme="printablechars" CrossAssemblyObfuscation="false" ExcludeXamlTypes="false" ControlFlowObfuscation="basic" PredefindSymbolNamesFilePath="" RenameMethodParameters="False">
      <RenamingExclusions />
      <AssemblyLoadPaths />
    </Obfuscation>
    <Secure SecureUserStrings="false" EncryptManagedResources="false" RedistName="AgileDotNetRT" RedistName64="AgileDotNetRT64" DisableRuntimeEmbedding="False" AntiDebuggerDetection="False" SkipSmallMethods="False" />
    <Tracking ConfigureErrorReporting="false" ProductName="AgileDotNet" ProductVersion="6.6.0.12" CompanyName="SecureTeam Software Ltd." />
    <CodeVirtualization PerformCodeVirtualization="false" RedistName="AgileDotNet.VMRuntime" />
    <LicenseFeatures />
  </Settings>
  <Licensing>
    <Licenses />
  </Licensing>
</AgileDotNet>