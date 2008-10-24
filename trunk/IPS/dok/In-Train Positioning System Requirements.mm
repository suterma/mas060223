<map version="0.8.1">
<!-- To view this file, download free mind mapping software FreeMind from http://freemind.sourceforge.net -->
<node CREATED="1224256247984" ID="Freemind_Link_498024001" MODIFIED="1224257018927" TEXT="In-Train Positioning System, possible Requirements">
<node CREATED="1224256267203" ID="_" MODIFIED="1224256275516" POSITION="right" TEXT="Precision">
<node CREATED="1224256276516" ID="Freemind_Link_1624245737" MODIFIED="1224258867610" TEXT="standard deviation is 25 meters max in the open field when all sensors are available">
<icon BUILTIN="full-2"/>
</node>
<node CREATED="1224256308625" ID="Freemind_Link_1657479503" MODIFIED="1224258296357" TEXT="It should focus on precise positions, not on the exact route">
<icon BUILTIN="full-1"/>
</node>
</node>
<node CREATED="1224256378532" ID="Freemind_Link_1894468138" MODIFIED="1224256380469" POSITION="left" TEXT="Output">
<node CREATED="1224256381782" ID="Freemind_Link_419474658" MODIFIED="1224257157709" TEXT="NMEA on RS-232">
<icon BUILTIN="full-1"/>
<node CREATED="1224256398876" ID="Freemind_Link_267782011" MODIFIED="1224256408517" TEXT="Sentences">
<node CREATED="1224256409454" ID="Freemind_Link_870421478" MODIFIED="1224277055125" TEXT="GGA (essential fix data which provide 3D location and accuracy data)">
<icon BUILTIN="full-2"/>
</node>
<node CREATED="1224256830660" ID="Freemind_Link_166795082" MODIFIED="1224257194709" TEXT="RMC (recommended minimum for GPS Receivers)">
<edge WIDTH="thin"/>
<icon BUILTIN="full-1"/>
</node>
</node>
<node CREATED="1224256521314" ID="Freemind_Link_785418643" MODIFIED="1224277061219" TEXT="Baud rate 4800, Data bit 8, Parity none, Stopbit 1, Handshake none">
<icon BUILTIN="full-1"/>
</node>
<node CREATED="1224256562861" ID="Freemind_Link_1814297758" MODIFIED="1224257205693" TEXT="Baud rate configurable">
<icon BUILTIN="full-2"/>
</node>
</node>
<node CREATED="1224257268960" ID="Freemind_Link_180713024" MODIFIED="1224257275491" TEXT="Virtual Comport">
<icon BUILTIN="full-2"/>
</node>
</node>
<node CREATED="1224256941582" ID="Freemind_Link_577105118" MODIFIED="1224275944250" POSITION="right" TEXT="Position providers">
<node CREATED="1224256946067" ID="Freemind_Link_795999915" MODIFIED="1224275972219" TEXT="Inertial 6DOF"/>
<node CREATED="1224256951114" ID="Freemind_Link_1788504614" MODIFIED="1224275974328" TEXT="WiFi"/>
<node CREATED="1224256955270" ID="Freemind_Link_1538764264" MODIFIED="1224275976797" TEXT="TrackDb"/>
<node CREATED="1224256979426" ID="Freemind_Link_149412872" MODIFIED="1224275978703" TEXT="User Markers"/>
<node CREATED="1224275989453" ID="Freemind_Link_1280540887" MODIFIED="1224276023719" TEXT="The system allows later adding of others"/>
</node>
<node CREATED="1224256989442" ID="Freemind_Link_1910021444" MODIFIED="1224256990880" POSITION="left" TEXT="GUI">
<node CREATED="1224257025958" ID="Freemind_Link_487668710" MODIFIED="1224257231616" TEXT="Presentation of subsequent markers"/>
<node CREATED="1224257037458" ID="Freemind_Link_1646787558" MODIFIED="1224257045552" TEXT="Show status for each sensor"/>
<node CREATED="1224257052083" ID="Freemind_Link_1927969493" MODIFIED="1224257984730" TEXT="Show status of output as colored icons"/>
<node CREATED="1224257065177" ID="Freemind_Link_1611923821" MODIFIED="1224257074818" TEXT="live output to Google Earth"/>
</node>
<node CREATED="1224257364538" ID="Freemind_Link_1483706135" MODIFIED="1224257381898" POSITION="right" TEXT="3rd Party Components">
<node CREATED="1224257383335" ID="Freemind_Link_37992285" MODIFIED="1224257437632" TEXT="Use only commercially usable">
<icon BUILTIN="full-2"/>
</node>
<node CREATED="1224257441726" ID="Freemind_Link_1460513107" MODIFIED="1224257461445" TEXT="Usage is generally encouraged">
<icon BUILTIN="full-1"/>
</node>
</node>
<node CREATED="1224257527742" ID="Freemind_Link_252415812" MODIFIED="1224257532805" POSITION="left" TEXT="Robustness">
<node CREATED="1224257534242" ID="Freemind_Link_1468060125" MODIFIED="1224257554258" TEXT="The system runs continuously for 10 hours"/>
<node CREATED="1224257568274" ID="Freemind_Link_437888158" MODIFIED="1224257648368" TEXT="The system continues to work without gps"/>
</node>
<node CREATED="1224257673634" ID="Freemind_Link_864463930" MODIFIED="1224257675290" POSITION="right" TEXT="Tests">
<node CREATED="1224257676665" ID="Freemind_Link_27013853" MODIFIED="1224258812985" TEXT="Accuracy after 1 minute in a Tunnel is as defined"/>
<node CREATED="1224257730556" ID="Freemind_Link_190926136" MODIFIED="1224257808760" TEXT="First output works when no user input, no GPS, but WiFi available"/>
<node CREATED="1224257766400" ID="Freemind_Link_430305837" MODIFIED="1224257799088" TEXT="First output works when user input, but no GPS and no WiFi"/>
<node CREATED="1224258732500" ID="Freemind_Link_401688349" MODIFIED="1224258775797" TEXT="The system does not crash, even when all sensors are removed">
<icon BUILTIN="full-1"/>
</node>
<node CREATED="1224258752375" ID="Freemind_Link_1473243984" MODIFIED="1224258918970" TEXT="The precision recovers, when one or more removed sensors are reattached">
<icon BUILTIN="full-2"/>
</node>
<node CREATED="1224258948095" ID="Freemind_Link_78851013" MODIFIED="1224259000174" TEXT="The functioning for each sensor implementation is proven separately">
<icon BUILTIN="full-1"/>
<node CREATED="1224256946067" ID="Freemind_Link_1425183536" MODIFIED="1224259365634" TEXT="Inertial 6DOF">
<icon BUILTIN="bookmark"/>
</node>
<node CREATED="1224256951114" ID="Freemind_Link_852793825" MODIFIED="1224259375117" TEXT="WiFi">
<icon BUILTIN="bookmark"/>
</node>
<node CREATED="1224256955270" ID="Freemind_Link_500997266" MODIFIED="1224259377929" TEXT="TrackDb">
<icon BUILTIN="bookmark"/>
</node>
<node CREATED="1224256979426" ID="Freemind_Link_1438475465" MODIFIED="1224259380522" TEXT="User Markers">
<icon BUILTIN="bookmark"/>
</node>
</node>
</node>
<node CREATED="1224258022902" ID="Freemind_Link_768209185" MODIFIED="1224258026261" POSITION="left" TEXT="Constraints">
<node CREATED="1224258028167" ID="Freemind_Link_1402791175" MODIFIED="1224258050433" TEXT="The systems runs on a standard Laptop plus additional Hardware"/>
<node CREATED="1224258054355" ID="Freemind_Link_901871310" MODIFIED="1224258074215" TEXT="The power supply is not part of the project"/>
<node CREATED="1224258083574" ID="Freemind_Link_1927431758" MODIFIED="1224258104902" TEXT="The GPS receiver is the ublox EVK-5H"/>
<node CREATED="1224258106652" ID="Freemind_Link_1970794910" MODIFIED="1224258119418" TEXT="The inertial unit is the MTI-G from XSens"/>
<node CREATED="1224258125293" ID="Freemind_Link_1742622218" MODIFIED="1224258168403" TEXT="The Laptop features an internal WiFi Card"/>
<node CREATED="1224258175387" ID="Freemind_Link_647054075" MODIFIED="1224258201965" TEXT="The Laptop is loaded with Windows XP professional SP3"/>
<node CREATED="1224258203403" ID="Freemind_Link_1974839227" MODIFIED="1224258224434" TEXT="The newest .NET Framework and Feature Packs may get used"/>
<node CREATED="1224258249903" ID="Freemind_Link_360799313" MODIFIED="1224258269450" TEXT="The data for the user markers and the track data is available as comma-separated Text files"/>
<node CREATED="1224258336763" ID="Freemind_Link_385350621" MODIFIED="1224258401873" TEXT="The mathematics for combining the inertial and gyro data with the other sensors is not part of the project."/>
</node>
<node CREATED="1224258407311" ID="Freemind_Link_604739844" MODIFIED="1224258460139" POSITION="left" TEXT="Data processing">
<node CREATED="1224258413701" ID="Freemind_Link_177434969" MODIFIED="1224259147331" TEXT="The data from all sensors is mixed to increase precision"/>
</node>
</node>
</map>
