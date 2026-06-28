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
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, -10.000000) * millimeter, vector(0.000000, 200.000000) * millimeter, vector(180.000000, 200.000000) * millimeter, vector(180.000000, -10.000000) * millimeter, vector(130.000000, -40.000000) * millimeter, vector(130.000000, -230.000000) * millimeter, vector(50.000000, -230.000000) * millimeter, vector(50.000000, -50.000000) * millimeter, vector(60.000000, -50.000000) * millimeter, vector(60.000000, -40.000000) * millimeter, vector(0.000000, -10.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(90.203001, 25.736981, 0.000000) * millimeter),
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

        // === Child Tab 3 from 1 (two_bend) ===
        // Flange 1->1_1_3: bend=23.96deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, -140.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 23.962605 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_1_3
        var wallFace1_1_3a = qClosestTo(qCreatedBy(id + "flange1_1_1_3a", EntityType.FACE), vector(45.430946, -140.000000, 2.030702) * millimeter);
        var faceN1_1_3a = evPlane(context, { "face" : wallFace1_1_3a }).normal;
        var skN1_1_3a = dot(faceN1_1_3a, vector(0.4061403217, 0.0, 0.9138107239)) >= 0 ? faceN1_1_3a : -faceN1_1_3a;
        var sketchRem1_1_3a = newSketchOnPlane(context, id + "sketchRem1_1_3a", { "sketchPlane" : plane(vector(40.8619, -230.0, 4.0614) * millimeter, skN1_1_3a, vector(0.9138107239, 0.0, -0.4061403217)) });
        skPolyline(sketchRem1_1_3a, "polyRem1_1_3a", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(7.999992, 0.000000) * millimeter, vector(7.999992, 180.000000) * millimeter, vector(0.000000, 180.000000) * millimeter, vector(-78.488594, 410.000000) * millimeter, vector(-86.488586, 410.000000) * millimeter, vector(-86.488586, 230.000000) * millimeter, vector(-78.488594, 230.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_3a);
        sheetMetalTab(context, id + "smTab1_1_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_3a"), vector(45.430946, -230.000000, 2.030702) * millimeter),
            "booleanUnionScope" : wallFace1_1_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_3->3: bend=66.04deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-40.000000, 90.000000, 40.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 66.037395 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_1_3_3b", EntityType.FACE), vector(-40.000000, 90.000000, 45.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(-1.0, 0.0, 0.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(-40.0, 180.0, 50.0) * millimeter, skN3b, vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(0.000000, -8.000000) * millimeter, vector(180.000000, -8.000000) * millimeter, vector(180.000000, 160.000000) * millimeter, vector(0.000000, 160.000000) * millimeter, vector(-170.731700, -40.000000) * millimeter, vector(-170.731700, -52.000000) * millimeter, vector(-96.498900, -52.000000) * millimeter, vector(-96.498900, -40.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(-40.000000, 90.000000, 50.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });
    });