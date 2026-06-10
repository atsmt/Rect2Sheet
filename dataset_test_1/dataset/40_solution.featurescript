FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(210.000000, 0.000000) * millimeter, vector(210.000000, 100.000000) * millimeter, vector(-10.000000, 100.000000) * millimeter, vector(-10.000000, 0.000000) * millimeter, vector(210.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(100.000000, 50.000000, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 1 from 0 (two_bend) ===
        // Flange 0->1_0_1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_1a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(210.000000, 50.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_1
        var sketchRem1_0_1a = newSketchOnPlane(context, id + "sketchRem1_0_1a", { "sketchPlane" : plane(vector(210.0, 0.0, -10.0) * millimeter, vector(-1.0, 0.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_1a, "polyRem1_0_1a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-81.930504, -127.773919) * millimeter, vector(-72.860038, -134.845589) * millimeter, vector(-2.143340, -64.140931) * millimeter, vector(-11.213805, -57.069262) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_1a);
        sheetMetalTab(context, id + "smTab1_0_1a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_1a"), vector(210.000000, 50.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_1a", EntityType.FACE), vector(210.000000, 50.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_1->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_1_1b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(210.000000, -99.493260, -49.501689) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1
        var sketchRem1b = newSketchOnPlane(context, id + "sketchRem1b", { "sketchPlane" : plane(vector(0.0, -64.1409314708, -14.1433396741) * millimeter, vector(0.0, 0.7071669837, -0.7070465735), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1b, "polyRem1b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(208.000000, 0.000000) * millimeter, vector(208.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1b);
        sheetMetalTab(context, id + "smTab1b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1b"), vector(205.000000, -99.493260, -49.501689) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_1_1b", EntityType.FACE), vector(205.000000, -99.493260, -49.501689) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0 (two_bend) ===
        // Flange 0->1_0_2: bend=93.76deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, 50.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 93.764941 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_2
        var wallFace1_0_2a = qClosestTo(qCreatedBy(id + "flange0_1_0_2a", EntityType.FACE), vector(-9.671683, 50.000000, -4.989209) * millimeter);
        var faceN1_0_2a = evPlane(context, { "face" : wallFace1_0_2a }).normal;
        var skN1_0_2a = dot(faceN1_0_2a, vector(0.9978418341, 0.0, 0.0656633387)) >= 0 ? faceN1_0_2a : -faceN1_0_2a;
        var sketchRem1_0_2a = newSketchOnPlane(context, id + "sketchRem1_0_2a", { "sketchPlane" : plane(vector(-9.3433666126, 100.0, -9.9784183413) * millimeter, skN1_0_2a, vector(-0.0656633387, 0.0, 0.9978418341)) });
        skPolyline(sketchRem1_0_2a, "polyRem1_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-121.656095, 254.350931) * millimeter, vector(-115.101149, 263.253316) * millimeter, vector(-297.007571, 356.326583) * millimeter, vector(-303.562517, 347.424198) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2a);
        sheetMetalTab(context, id + "smTab1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2a"), vector(-9.671683, 100.000000, -4.989209) * millimeter),
            "booleanUnionScope" : wallFace1_0_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2->2: bend=91.72deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(4.318177, -209.789950, -217.583762) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 91.716869 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange1_0_2_2b", EntityType.FACE), vector(9.309627, -209.656590, -217.323680) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(0.0, -0.8898388639, 0.4562749131)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(100.0, -162.6747676879, -125.6985436358) * millimeter, skN2b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(99.657534, 1.151070) * millimeter, vector(87.712951, 205.136134) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(9.309627, -162.674768, -125.698544) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });
    });