cd C:\github\lcasillas\Source\Repos\hta-orl-2016-virtual-deck\docs
call make-html.bat
cd C:\github\lcasillas\Source\Repos\hta-orl-2016-virtual-deck\docs\build\html
start firefox.exe http://localhost:8000/
python -m pelican.server
