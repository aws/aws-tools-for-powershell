/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// For a given input face ID, searches for matching faces in the collection the face
    /// belongs to. You get a face ID when you add a face to the collection using the <a>IndexFaces</a>
    /// operation. The operation compares the features of the input face with faces in the
    /// specified collection. 
    /// 
    ///  <note><para>
    /// You can also search faces without indexing faces by using the <code>SearchFacesByImage</code>
    /// operation.
    /// </para></note><para>
    ///  The operation response returns an array of faces that match, ordered by similarity
    /// score with the highest similarity first. More specifically, it is an array of metadata
    /// for each face match that is found. Along with the metadata, the response also includes
    /// a <code>confidence</code> value for each face match, indicating the confidence that
    /// the specific face matches the input face. 
    /// </para><para>
    /// For an example, see <a>example3</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <code>rekognition:SearchFaces</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "REKFace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.SearchFacesResponse")]
    [AWSCmdlet("Invokes the SearchFaces operation against Amazon Rekognition.", Operation = new[] {"SearchFaces"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.SearchFacesResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.SearchFacesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchREKFaceCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>ID of the collection the face belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter FaceId
        /// <summary>
        /// <para>
        /// <para>ID of a face to find matches for in the collection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FaceId { get; set; }
        #endregion
        
        #region Parameter FaceMatchThreshold
        /// <summary>
        /// <para>
        /// <para>Optional value specifying the minimum confidence in the face match to return. For
        /// example, don't return any matches where confidence in matches is less than 70%.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Single FaceMatchThreshold { get; set; }
        #endregion
        
        #region Parameter MaxFace
        /// <summary>
        /// <para>
        /// <para>Maximum number of faces to return. The operation returns the maximum number of faces
        /// with the highest confidence in the match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxFaces")]
        public System.Int32 MaxFace { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CollectionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-REKFace (SearchFaces)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CollectionId = this.CollectionId;
            context.FaceId = this.FaceId;
            if (ParameterWasBound("FaceMatchThreshold"))
                context.FaceMatchThreshold = this.FaceMatchThreshold;
            if (ParameterWasBound("MaxFace"))
                context.MaxFaces = this.MaxFace;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Rekognition.Model.SearchFacesRequest();
            
            if (cmdletContext.CollectionId != null)
            {
                request.CollectionId = cmdletContext.CollectionId;
            }
            if (cmdletContext.FaceId != null)
            {
                request.FaceId = cmdletContext.FaceId;
            }
            if (cmdletContext.FaceMatchThreshold != null)
            {
                request.FaceMatchThreshold = cmdletContext.FaceMatchThreshold.Value;
            }
            if (cmdletContext.MaxFaces != null)
            {
                request.MaxFaces = cmdletContext.MaxFaces.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.SearchFacesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.SearchFacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "SearchFaces");
            #if DESKTOP
            return client.SearchFaces(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SearchFacesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CollectionId { get; set; }
            public System.String FaceId { get; set; }
            public System.Single? FaceMatchThreshold { get; set; }
            public System.Int32? MaxFaces { get; set; }
        }
        
    }
}
