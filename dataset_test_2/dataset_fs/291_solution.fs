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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(200.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 100.000000) * millimeter, vector(200.000000, 100.000000) * millimeter, vector(200.000000, -10.000000) * millimeter, vector(0.000000, -10.000000) * millimeter, vector(0.000000, 100.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(100.000000, 45.000000, 0.000000) * millimeter),
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

        // === Child Tab 2 from 0 (two_bend) ===
        // Flange 0->1_0_2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(100.000000, -10.000000, 0.000000) * millimeter),
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

        // Remaining polygon for tab 1_0_2
        var sketchRem1_0_2a = newSketchOnPlane(context, id + "sketchRem1_0_2a", { "sketchPlane" : plane(vector(200.0, -10.0, -10.0) * millimeter, vector(0.0, -1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem1_0_2a, "polyRem1_0_2a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(8.000000, 0.000000) * millimeter, vector(8.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(-230.000000, -40.000000) * millimeter, vector(-228.000000, -50.000000) * millimeter, vector(-28.000000, -50.000000) * millimeter, vector(-30.000000, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2a);
        sheetMetalTab(context, id + "smTab1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2a"), vector(100.000000, -10.000000, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1_0_2a", EntityType.FACE), vector(100.000000, -10.000000, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(250.000000, -10.000000, -140.000000) * millimeter),
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

        // Remaining polygon for tab 2
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(250.0, 100.0, -40.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(2.000000, -10.000000) * millimeter, vector(102.000000, -10.000000) * millimeter, vector(100.000000, 0.000000) * millimeter, vector(108.000000, 0.000000) * millimeter, vector(108.000000, 200.000000) * millimeter, vector(-8.000000, 200.000000) * millimeter, vector(-8.000000, 0.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(250.000000, -5.000000, -140.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_0_2_2b", EntityType.FACE), vector(250.000000, -5.000000, -140.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 2 (two_bend) ===
        // Flange 2->1_2_3: bend=86.19deg, zone=10mm
        sheetMetalFlange(context, id + "flange2_1_2_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(250.000000, 110.000000, -140.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 86.194462 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_2_3
        var wallFace1_2_3a = qClosestTo(qCreatedBy(id + "flange2_1_2_3a", EntityType.FACE), vector(254.988975, 109.668148, -140.000000) * millimeter);
        var faceN1_2_3a = evPlane(context, { "face" : wallFace1_2_3a }).normal;
        var skN1_2_3a = dot(faceN1_2_3a, vector(0.0663703365, 0.9977950583, 0.0)) >= 0 ? faceN1_2_3a : -faceN1_2_3a;
        var sketchRem1_2_3a = newSketchOnPlane(context, id + "sketchRem1_2_3a", { "sketchPlane" : plane(vector(259.9779, 109.3363, -240.0) * millimeter, skN1_2_3a, vector(-0.9977950583, 0.0663703365, 0.0)) });
        skPolyline(sketchRem1_2_3a, "polyRem1_2_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999949, 0.000000) * millimeter, vector(7.999949, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(-41.217288, 220.000000) * millimeter, vector(-39.217288, 230.000000) * millimeter, vector(-143.642856, 230.000000) * millimeter, vector(-145.642856, 220.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_2_3a);
        sheetMetalTab(context, id + "smTab1_2_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_2_3a"), vector(254.988975, 109.668148, -240.000000) * millimeter),
            "booleanUnionScope" : wallFace1_2_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_2_3->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_2_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(353.201950, 103.135100, -10.000000) * millimeter),
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

        // Remaining polygon for tab 3
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(300.0, 90.0, -10.0) * millimeter, vector(0.0, 0.0, 1.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(70.000000, 0.000000) * millimeter, vector(70.000000, 100.000000) * millimeter, vector(0.308400, 104.635800) * millimeter, vector(-7.674010, 105.166855) * millimeter, vector(-14.605010, 0.971555) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(352.870087, 98.146125, -10.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange1_2_3_3b", EntityType.FACE), vector(352.870087, 98.146125, -10.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });