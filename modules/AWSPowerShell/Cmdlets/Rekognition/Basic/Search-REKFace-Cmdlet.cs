/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// For a given input face ID, searches for matching faces in the collection the face
    /// belongs to. You get a face ID when you add a face to the collection using the <a>IndexFaces</a>
    /// operation. The operation compares the features of the input face with faces in the
    /// specified collection. 
    /// 
    ///  <note><para>
    /// You can also search faces without indexing faces by using the <c>SearchFacesByImage</c>
    /// operation.
    /// </para></note><para>
    ///  The operation response returns an array of faces that match, ordered by similarity
    /// score with the highest similarity first. More specifically, it is an array of metadata
    /// for each face match that is found. Along with the metadata, the response also includes
    /// a <c>confidence</c> value for each face match, indicating the confidence that the
    /// specific face matches the input face. 
    /// </para><para>
    /// For an example, see Searching for a face using its face ID in the Amazon Rekognition
    /// Developer Guide.
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:SearchFaces</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "REKFace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.SearchFacesResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition SearchFaces API operation.", Operation = new[] {"SearchFaces"}, SelectReturnType = typeof(Amazon.Rekognition.Model.SearchFacesResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.SearchFacesResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.SearchFacesResponse object containing multiple properties."
    )]
    public partial class SearchREKFaceCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>ID of the collection the face belongs to.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter FaceId
        /// <summary>
        /// <para>
        /// <para>ID of a face to find matches for in the collection.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FaceId { get; set; }
        #endregion
        
        #region Parameter FaceMatchThreshold
        /// <summary>
        /// <para>
        /// <para>Optional value specifying the minimum confidence in the face match to return. For
        /// example, don't return any matches where confidence in matches is less than 70%. The
        /// default value is 80%. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? FaceMatchThreshold { get; set; }
        #endregion
        
        #region Parameter MaxFace
        /// <summary>
        /// <para>
        /// <para>Maximum number of faces to return. The operation returns the maximum number of faces
        /// with the highest confidence in the match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxFaces")]
        public System.Int32? MaxFace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.SearchFacesResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.SearchFacesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-REKFace (SearchFaces)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.SearchFacesResponse, SearchREKFaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollectionId = this.CollectionId;
            #if MODULAR
            if (this.CollectionId == null && ParameterWasBound(nameof(this.CollectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FaceId = this.FaceId;
            #if MODULAR
            if (this.FaceId == null && ParameterWasBound(nameof(this.FaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter FaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FaceMatchThreshold = this.FaceMatchThreshold;
            context.MaxFace = this.MaxFace;
            
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
            if (cmdletContext.MaxFace != null)
            {
                request.MaxFaces = cmdletContext.MaxFace.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            try
            {
                return client.SearchFacesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String CollectionId { get; set; }
            public System.String FaceId { get; set; }
            public System.Single? FaceMatchThreshold { get; set; }
            public System.Int32? MaxFace { get; set; }
            public System.Func<Amazon.Rekognition.Model.SearchFacesResponse, SearchREKFaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
