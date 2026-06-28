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
        skPolyline(sketch0, "poly0", { "points" : [vector(-32.413800, 150.000000) * millimeter, vector(-32.413800, 160.000000) * millimeter, vector(-5.338100, 160.000000) * millimeter, vector(-5.338100, 150.000000) * millimeter, vector(-60.000000, 0.000000) * millimeter, vector(-220.000000, 0.000000) * millimeter, vector(-220.000000, 140.000000) * millimeter, vector(-60.000000, 140.000000) * millimeter, vector(-32.413800, 150.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(-124.111054, 75.085105, 0.000000) * millimeter),
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
        // Flange 0->1_0_2: bend=54.69deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_2a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(70.000000, -10.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 54.688514 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_0_2
        var wallFace1_0_2a = qClosestTo(qCreatedBy(id + "flange0_1_0_2a", EntityType.FACE), vector(70.000000, -7.109894, 4.080109) * millimeter);
        var faceN1_0_2a = evPlane(context, { "face" : wallFace1_0_2a }).normal;
        var skN1_0_2a = dot(faceN1_0_2a, vector(0.0, -0.8160217296, 0.5780212252)) >= 0 ? faceN1_0_2a : -faceN1_0_2a;
        var sketchRem1_0_2a = newSketchOnPlane(context, id + "sketchRem1_0_2a", { "sketchPlane" : plane(vector(0.0, -4.2198, 8.1602) * millimeter, skN1_0_2a, vector(0.0, -0.5780212252, -0.8160217296)) });
        skPolyline(sketchRem1_0_2a, "polyRem1_0_2a", { "points" : [vector(7.999979, 0.000000) * millimeter, vector(7.999979, 140.000000) * millimeter, vector(-282.108845, 140.000000) * millimeter, vector(-282.108845, 0.000000) * millimeter, vector(7.999979, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_2a);
        sheetMetalTab(context, id + "smTab1_0_2a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_2a"), vector(0.000000, -7.109894, 4.080109) * millimeter),
            "booleanUnionScope" : wallFace1_0_2a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_2->2: bend=144.69deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_2_2b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(70.000000, 160.000000, 240.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 144.688514 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var wallFace2b = qClosestTo(qCreatedBy(id + "flange1_0_2_2b", EntityType.FACE), vector(70.000000, 160.000000, 235.000000) * millimeter);
        var faceN2b = evPlane(context, { "face" : wallFace2b }).normal;
        var skN2b = dot(faceN2b, vector(0.0, 1.0, 0.0)) >= 0 ? faceN2b : -faceN2b;
        var sketchRem2b = newSketchOnPlane(context, id + "sketchRem2b", { "sketchPlane" : plane(vector(140.0, 160.0, 50.0) * millimeter, skN2b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem2b, "polyRem2b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(145.338100, -40.000000) * millimeter, vector(145.338100, -48.000000) * millimeter, vector(172.413800, -48.000000) * millimeter, vector(172.413800, -40.000000) * millimeter, vector(140.000000, 0.000000) * millimeter, vector(140.000000, 188.000000) * millimeter, vector(0.000000, 188.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2b);
        sheetMetalTab(context, id + "smTab2b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2b"), vector(70.000000, 160.000000, 50.000000) * millimeter),
            "booleanUnionScope" : wallFace2b,
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0 (one_bend) ===
        // Flange 0->3: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_3", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(167.556100, 160.000000, 0.000000) * millimeter),
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
        var sketchRem3 = newSketchOnPlane(context, id + "sketchRem3", { "sketchPlane" : plane(vector(200.0, 160.0, 230.0) * millimeter, vector(0.0, 1.0, 0.0), vector(0.0, 0.0, 1.0)) });
        skPolyline(sketchRem3, "polyRem3", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(-220.000000, -59.549700) * millimeter, vector(-228.000000, -59.549700) * millimeter, vector(-228.000000, -5.338100) * millimeter, vector(-220.000000, -5.338100) * millimeter, vector(-180.000000, 0.000000) * millimeter, vector(-180.000000, 180.000000) * millimeter, vector(0.000000, 180.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3);
        sheetMetalTab(context, id + "smTab3", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3"), vector(167.556100, 160.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_3", EntityType.FACE), vector(167.556100, 160.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });
    });