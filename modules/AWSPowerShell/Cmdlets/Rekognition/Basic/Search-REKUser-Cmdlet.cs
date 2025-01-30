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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Searches for UserIDs within a collection based on a <c>FaceId</c> or <c>UserId</c>.
    /// This API can be used to find the closest UserID (with a highest similarity) to associate
    /// a face. The request must be provided with either <c>FaceId</c> or <c>UserId</c>. The
    /// operation returns an array of UserID that match the <c>FaceId</c> or <c>UserId</c>,
    /// ordered by similarity score with the highest similarity first.
    /// </summary>
    [Cmdlet("Search", "REKUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.SearchUsersResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition SearchUsers API operation.", Operation = new[] {"SearchUsers"}, SelectReturnType = typeof(Amazon.Rekognition.Model.SearchUsersResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.SearchUsersResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.SearchUsersResponse object containing multiple properties."
    )]
    public partial class SearchREKUserCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing collection containing the UserID, used with a UserId or FaceId.
        /// If a FaceId is provided, UserId isn’t required to be present in the Collection.</para>
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
        /// <para>ID for the existing face.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FaceId { get; set; }
        #endregion
        
        #region Parameter MaxUser
        /// <summary>
        /// <para>
        /// <para>Maximum number of identities to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxUsers")]
        public System.Int32? MaxUser { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>ID for the existing User.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter UserMatchThreshold
        /// <summary>
        /// <para>
        /// <para>Optional value that specifies the minimum confidence in the matched UserID to return.
        /// Default value of 80.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? UserMatchThreshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.SearchUsersResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.SearchUsersResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-REKUser (SearchUsers)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.SearchUsersResponse, SearchREKUserCmdlet>(Select) ??
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
            context.CollectionId = this.CollectionId;
            #if MODULAR
            if (this.CollectionId == null && ParameterWasBound(nameof(this.CollectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FaceId = this.FaceId;
            context.MaxUser = this.MaxUser;
            context.UserId = this.UserId;
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
            var request = new Amazon.Rekognition.Model.SearchUsersRequest();
            
            if (cmdletContext.CollectionId != null)
            {
                request.CollectionId = cmdletContext.CollectionId;
            }
            if (cmdletContext.FaceId != null)
            {
                request.FaceId = cmdletContext.FaceId;
            }
            if (cmdletContext.MaxUser != null)
            {
                request.MaxUsers = cmdletContext.MaxUser.Value;
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
        
        private Amazon.Rekognition.Model.SearchUsersResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.SearchUsersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "SearchUsers");
            try
            {
                #if DESKTOP
                return client.SearchUsers(request);
                #elif CORECLR
                return client.SearchUsersAsync(request).GetAwaiter().GetResult();
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
            public System.String CollectionId { get; set; }
            public System.String FaceId { get; set; }
            public System.Int32? MaxUser { get; set; }
            public System.String UserId { get; set; }
            public System.Single? UserMatchThreshold { get; set; }
            public System.Func<Amazon.Rekognition.Model.SearchUsersResponse, SearchREKUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
