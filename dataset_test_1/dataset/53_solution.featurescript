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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(51.322331, -40.000000) * millimeter, vector(51.322331, -50.000000) * millimeter, vector(133.809902, -50.000000) * millimeter, vector(133.809902, -40.000000) * millimeter, vector(200.000000, 0.000000) * millimeter, vector(200.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(99.085165, 32.693714, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=45.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(92.566117, -50.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 45.004878 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var wallFace1 = qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(92.566117, -53.535233, -3.535835) * millimeter);
        var faceN1 = evPlane(context, { "face" : wallFace1 }).normal;
        var skN1 = dot(faceN1, vector(0.0, 0.7071669837, -0.7070465735)) >= 0 ? faceN1 : -faceN1;
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(0.0, -64.1409314708, -14.1433396741) * millimeter, skN1, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(51.322331, -10.000000) * millimeter, vector(51.322331, -18.000000) * millimeter, vector(133.809902, -18.000000) * millimeter, vector(133.809902, -10.000000) * millimeter, vector(180.000000, 0.000000) * millimeter, vector(180.000000, 100.000000) * millimeter, vector(0.000000, 100.000000) * millimeter, vector(-10.000000, 98.000000) * millimeter, vector(-10.000000, -2.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(92.566117, -64.140931, -14.143340) * millimeter),
            "booleanUnionScope" : wallFace1,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 1 (two_bend) ===
        // Flange 1->1_1_2: bend=74.19deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-10.000000, -99.493260, -49.501689) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 74.188970 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_1_2
        var wallFace1_1_2a = qClosestTo(qCreatedBy(id + "flange1_1_1_2a", EntityType.FACE), vector(-8.637673, -96.091202, -52.903168) * millimeter);
        var faceN1_1_2a = evPlane(context, { "face" : wallFace1_1_2a }).normal;
        var skN1_1_2a = dot(faceN1_1_2a, vector(-0.9621655568, 0.1926785963, -0.1926457887)) >= 0 ? faceN1_1_2a : -faceN1_1_2a;
        var sketchRem1_1_2a = newSketchOnPlane(context, id + "sketchRem1_1_2a", { "sketchPlane" : plane(vector(-7.2753451348, -128.0414716787, -91.6629966458) * millimeter, skN1_1_2a, vector(-0.2724654865, -0.6804117146, 0.6802958601)) });
        skPolyline(sketchRem1_1_2a, "polyRem1_1_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, -0.000000) * millimeter, vector(8.000000, 100.000000) * millimeter, vector(-0.000000, 100.000000) * millimeter, vector(-75.219603, -243.140007) * millimeter, vector(-63.736531, -246.313547) * millimeter, vector(1.691811, -50.802609) * millimeter, vector(-9.791260, -47.629069) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_2a);
        sheetMetalTab(context, id + "smTab1_1_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_2a"), vector(-8.637673, -131.443530, -88.261517) * millimeter),
            "booleanUnionScope" : wallFace1_1_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_2->2: bend=74.97deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(1.722108, -210.610151, -219.183339) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 74.968364 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange1_1_2_2b", EntityType.FACE), vector(6.703381, -210.412885, -218.798626) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(0.0, -0.8898388639, 0.4562749131)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(100.0, -162.6747676879, -125.6985436358) * millimeter, skN2b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(80.000000, 0.000000) * millimeter, vector(105.198865, 2.187087) * millimeter, vector(87.371900, 207.583275) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(6.703381, -162.674768, -125.698544) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });
    });