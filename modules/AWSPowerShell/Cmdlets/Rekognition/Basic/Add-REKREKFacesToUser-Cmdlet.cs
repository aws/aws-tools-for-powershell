/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Associates one or more faces with an existing UserID. Takes an array of <code>FaceIds</code>.
    /// Each <code>FaceId</code> that are present in the <code>FaceIds</code> list is associated
    /// with the provided UserID. The maximum number of total <code>FaceIds</code> per UserID
    /// is 100. 
    /// 
    ///  
    /// <para>
    /// The <code>UserMatchThreshold</code> parameter specifies the minimum user match confidence
    /// required for the face to be associated with a UserID that has at least one <code>FaceID</code>
    /// already associated. This ensures that the <code>FaceIds</code> are associated with
    /// the right UserID. The value ranges from 0-100 and default value is 75. 
    /// </para><para>
    /// If successful, an array of <code>AssociatedFace</code> objects containing the associated
    /// <code>FaceIds</code> is returned. If a given face is already associated with the given
    /// <code>UserID</code>, it will be ignored and will not be returned in the response.
    /// If a given face is already associated to a different <code>UserID</code>, isn't found
    /// in the collection, doesn’t meet the <code>UserMatchThreshold</code>, or there are
    /// already 100 faces associated with the <code>UserID</code>, it will be returned as
    /// part of an array of <code>UnsuccessfulFaceAssociations.</code></para><para>
    /// The <code>UserStatus</code> reflects the status of an operation which updates a UserID
    /// representation with a list of given faces. The <code>UserStatus</code> can be: 
    /// </para><ul><li><para>
    /// ACTIVE - All associations or disassociations of FaceID(s) for a UserID are complete.
    /// </para></li><li><para>
    /// CREATED - A UserID has been created, but has no FaceID(s) associated with it.
    /// </para></li><li><para>
    /// UPDATING - A UserID is being updated and there are current associations or disassociations
    /// of FaceID(s) taking place.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Add", "REKREKFacesToUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.AssociateFacesResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition AssociateFaces API operation.", Operation = new[] {"AssociateFaces"}, SelectReturnType = typeof(Amazon.Rekognition.Model.AssociateFacesResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.AssociateFacesResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.AssociateFacesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddREKREKFacesToUserCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotent token used to identify the request to <code>AssociateFaces</code>. If you
        /// use the same token with multiple <code>AssociateFaces</code> requests, the same response
        /// is returned. Use ClientRequestToken to prevent the same request from being processed
        /// more than once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing collection containing the UserID.</para>
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
        /// <para>An array of FaceIDs to associate with the UserID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FaceIds")]
        public System.String[] FaceId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The ID for the existing UserID.</para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter UserMatchThreshold
        /// <summary>
        /// <para>
        /// <para>An optional value specifying the minimum confidence in the UserID match to return.
        /// The default value is 75.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? UserMatchThreshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.AssociateFacesResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.AssociateFacesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CollectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CollectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CollectionId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-REKREKFacesToUser (AssociateFaces)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.AssociateFacesResponse, AddREKREKFacesToUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CollectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.CollectionId = this.CollectionId;
            #if MODULAR
            if (this.CollectionId == null && ParameterWasBound(nameof(this.CollectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FaceId != null)
            {
                context.FaceId = new List<System.String>(this.FaceId);
            }
            #if MODULAR
            if (this.FaceId == null && ParameterWasBound(nameof(this.FaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter FaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserMatchThreshold = this.UserMatchThreshold;
            
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
            var request = new Amazon.Rekognition.Model.AssociateFacesRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CollectionId != null)
            {
                request.CollectionId = cmdletContext.CollectionId;
            }
            if (cmdletContext.FaceId != null)
            {
                request.FaceIds = cmdletContext.FaceId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            if (cmdletContext.UserMatchThreshold != null)
            {
                request.UserMatchThreshold = cmdletContext.UserMatchThreshold.Value;
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
        
        private Amazon.Rekognition.Model.AssociateFacesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.AssociateFacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "AssociateFaces");
            try
            {
                #if DESKTOP
                return client.AssociateFaces(request);
                #elif CORECLR
                return client.AssociateFacesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String ClientRequestToken { get; set; }
            public System.String CollectionId { get; set; }
            public List<System.String> FaceId { get; set; }
            public System.String UserId { get; set; }
            public System.Single? UserMatchThreshold { get; set; }
            public System.Func<Amazon.Rekognition.Model.AssociateFacesResponse, AddREKREKFacesToUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
