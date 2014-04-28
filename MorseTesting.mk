##
## Auto Generated makefile by CodeLite IDE
## any manual changes will be erased      
##
## Debug
ProjectName            :=MorseTesting
ConfigurationName      :=Debug
WorkspacePath          := "C:\CppCode\Testing\MorseTesting"
ProjectPath            := "C:\CppCode\Testing\MorseTesting"
IntermediateDirectory  :=./Debug
OutDir                 := $(IntermediateDirectory)
CurrentFileName        :=
CurrentFilePath        :=
CurrentFileFullPath    :=
User                   :=Schmitt
Date                   :=02/20/14
CodeLitePath           :="C:\Program Files (x86)\CodeLite"
LinkerName             :=g++
SharedObjectLinkerName :=g++ -shared -fPIC
ObjectSuffix           :=.o
DependSuffix           :=.o.d
PreprocessSuffix       :=.o.i
DebugSwitch            :=-gstab
IncludeSwitch          :=-I
LibrarySwitch          :=-l
OutputSwitch           :=-o 
LibraryPathSwitch      :=-L
PreprocessorSwitch     :=-D
SourceSwitch           :=-c 
OutputFile             :=$(IntermediateDirectory)/$(ProjectName)
Preprocessors          :=
ObjectSwitch           :=-o 
ArchiveOutputSwitch    := 
PreprocessOnlySwitch   :=-E 
ObjectsFileList        :="MorseTesting.txt"
PCHCompileFlags        :=
MakeDirCommand         :=makedir
RcCmpOptions           := 
RcCompilerName         :=windres
LinkOptions            :=  
IncludePath            :=  $(IncludeSwitch). $(IncludeSwitch)C:/MinGW/include $(IncludeSwitch)C:/cppLibs/portaudio/include $(IncludeSwitch)C:/MinGW-4.8.1/include $(IncludeSwitch)C:/cppLibs/portaudio/include 
IncludePCH             := 
RcIncludePath          := $(IncludeSwitch). $(IncludeSwitch)C:/MinGW/include $(IncludeSwitch)C:/cppLibs/portaudio/include $(IncludeSwitch). $(IncludeSwitch)C:/MinGW/include $(IncludeSwitch)C:/cppLibs/portaudio/include 
Libs                   := $(LibrarySwitch)portaudio $(LibrarySwitch)portaudio 
ArLibs                 :=  "portaudio" "portaudio" 
LibPath                := $(LibraryPathSwitch). $(LibraryPathSwitch)C:/MinGW/lib $(LibraryPathSwitch)C:/cppLibs/portaudio/lib $(LibraryPathSwitch)C:/MinGW/lib $(LibraryPathSwitch)C:/cppLibs/portaudio/lib $(LibraryPathSwitch)C:/MinGW-4.8.1/lib 

##
## Common variables
## AR, CXX, CC, AS, CXXFLAGS and CFLAGS can be overriden using an environment variables
##
AR       := ar rcus
CXX      := g++
CC       := gcc
CXXFLAGS :=  -g -O0 -Wall $(Preprocessors)
CFLAGS   :=  -g -O0 -Wall $(Preprocessors)
ASFLAGS  := 
AS       := as


##
## User defined environment variables
##
CodeLiteDir:=C:\Program Files (x86)\CodeLite
UNIT_TEST_PP_SRC_DIR:=C:\UnitTest++-1.3
Objects0=$(IntermediateDirectory)/main$(ObjectSuffix) $(IntermediateDirectory)/morsebeep$(ObjectSuffix) $(IntermediateDirectory)/port_audio_std$(ObjectSuffix) 



Objects=$(Objects0) 

##
## Main Build Targets 
##
.PHONY: all clean PreBuild PrePreBuild PostBuild
all: $(OutputFile)

$(OutputFile): $(IntermediateDirectory)/.d $(Objects) 
	@$(MakeDirCommand) $(@D)
	@echo "" > $(IntermediateDirectory)/.d
	@echo $(Objects0)  > $(ObjectsFileList)
	$(LinkerName) $(OutputSwitch)$(OutputFile) @$(ObjectsFileList) $(LibPath) $(Libs) $(LinkOptions)

$(IntermediateDirectory)/.d:
	@$(MakeDirCommand) "./Debug"

PreBuild:


##
## Objects
##
$(IntermediateDirectory)/main$(ObjectSuffix): main.cpp $(IntermediateDirectory)/main$(DependSuffix)
	$(CXX) $(IncludePCH) $(SourceSwitch) "C:/CppCode/Testing/MorseTesting/main.cpp" $(CXXFLAGS) $(ObjectSwitch)$(IntermediateDirectory)/main$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/main$(DependSuffix): main.cpp
	@$(CXX) $(CXXFLAGS) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/main$(ObjectSuffix) -MF$(IntermediateDirectory)/main$(DependSuffix) -MM "main.cpp"

$(IntermediateDirectory)/main$(PreprocessSuffix): main.cpp
	@$(CXX) $(CXXFLAGS) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/main$(PreprocessSuffix) "main.cpp"

$(IntermediateDirectory)/morsebeep$(ObjectSuffix): morsebeep.cpp $(IntermediateDirectory)/morsebeep$(DependSuffix)
	$(CXX) $(IncludePCH) $(SourceSwitch) "C:/CppCode/Testing/MorseTesting/morsebeep.cpp" $(CXXFLAGS) $(ObjectSwitch)$(IntermediateDirectory)/morsebeep$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/morsebeep$(DependSuffix): morsebeep.cpp
	@$(CXX) $(CXXFLAGS) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/morsebeep$(ObjectSuffix) -MF$(IntermediateDirectory)/morsebeep$(DependSuffix) -MM "morsebeep.cpp"

$(IntermediateDirectory)/morsebeep$(PreprocessSuffix): morsebeep.cpp
	@$(CXX) $(CXXFLAGS) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/morsebeep$(PreprocessSuffix) "morsebeep.cpp"

$(IntermediateDirectory)/port_audio_std$(ObjectSuffix): port_audio_std.cpp $(IntermediateDirectory)/port_audio_std$(DependSuffix)
	$(CXX) $(IncludePCH) $(SourceSwitch) "C:/CppCode/Testing/MorseTesting/port_audio_std.cpp" $(CXXFLAGS) $(ObjectSwitch)$(IntermediateDirectory)/port_audio_std$(ObjectSuffix) $(IncludePath)
$(IntermediateDirectory)/port_audio_std$(DependSuffix): port_audio_std.cpp
	@$(CXX) $(CXXFLAGS) $(IncludePCH) $(IncludePath) -MG -MP -MT$(IntermediateDirectory)/port_audio_std$(ObjectSuffix) -MF$(IntermediateDirectory)/port_audio_std$(DependSuffix) -MM "port_audio_std.cpp"

$(IntermediateDirectory)/port_audio_std$(PreprocessSuffix): port_audio_std.cpp
	@$(CXX) $(CXXFLAGS) $(IncludePCH) $(IncludePath) $(PreprocessOnlySwitch) $(OutputSwitch) $(IntermediateDirectory)/port_audio_std$(PreprocessSuffix) "port_audio_std.cpp"


-include $(IntermediateDirectory)/*$(DependSuffix)
##
## Clean
##
clean:
	$(RM) $(IntermediateDirectory)/*.*
	$(RM) $(OutputFile)
	$(RM) $(OutputFile).exe
	$(RM) ".build-debug/MorseTesting"


