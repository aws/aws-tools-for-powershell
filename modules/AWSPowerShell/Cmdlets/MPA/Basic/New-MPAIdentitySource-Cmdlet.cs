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
using Amazon.MPA;
using Amazon.MPA.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MPA
{
    /// <summary>
    /// Creates a new identity source. For more information, see <a href="https://docs.aws.amazon.com/mpa/latest/userguide/mpa-concepts.html">Identity
    /// Source</a> in the <i>Multi-party approval User Guide</i>.
    /// </summary>
    [Cmdlet("New", "MPAIdentitySource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MPA.Model.CreateIdentitySourceResponse")]
    [AWSCmdlet("Calls the AWS Multi-party Approval CreateIdentitySource API operation.", Operation = new[] {"CreateIdentitySource"}, SelectReturnType = typeof(Amazon.MPA.Model.CreateIdentitySourceResponse))]
    [AWSCmdletOutput("Amazon.MPA.Model.CreateIdentitySourceResponse",
        "This cmdlet returns an Amazon.MPA.Model.CreateIdentitySourceResponse object containing multiple properties."
    )]
    public partial class NewMPAIdentitySourceCmdlet : AmazonMPAClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IamIdentityCenter_InstanceArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) for the IAM Identity Center instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentitySourceParameters_IamIdentityCenter_InstanceArn")]
        public System.String IamIdentityCenter_InstanceArn { get; set; }
        #endregion
        
        #region Parameter IamIdentityCenter_Region
        /// <summary>
        /// <para>
        /// <para>Amazon Web Services Region where the IAM Identity Center instance is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentitySourceParameters_IamIdentityCenter_Region")]
        public System.String IamIdentityCenter_Region { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tag you want to attach to the identity source.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If not provided, the Amazon Web Services populates this field.</para><note><para><b>What is idempotency?</b></para><para>When you make a mutating API request, the request typically returns a result before
        /// the operation's asynchronous workflows have completed. Operations might also time
        /// out or encounter other server issues before they complete, even though the request
        /// has already returned a result. This could make it difficult to determine whether the
        /// request succeeded or not, and could lead to multiple retries to ensure that the operation
        /// completes successfully. However, if the original request and the subsequent retries
        /// are successful, the operation is completed multiple times. This means that you might
        /// create more resources than you intended.</para><para><i>Idempotency</i> ensures that an API request completes no more than one time. With
        /// an idempotent request, if the original request completes successfully, any subsequent
        /// retries complete successfully without performing any further actions.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MPA.Model.CreateIdentitySourceResponse).
        /// Specifying the name of a property of type Amazon.MPA.Model.CreateIdentitySourceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IamIdentityCenter_InstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MPAIdentitySource (CreateIdentitySource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MPA.Model.CreateIdentitySourceResponse, NewMPAIdentitySourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.IamIdentityCenter_InstanceArn = this.IamIdentityCenter_InstanceArn;
            context.IamIdentityCenter_Region = this.IamIdentityCenter_Region;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.MPA.Model.CreateIdentitySourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate IdentitySourceParameters
            var requestIdentitySourceParametersIsNull = true;
            request.IdentitySourceParameters = new Amazon.MPA.Model.IdentitySourceParameters();
            Amazon.MPA.Model.IamIdentityCenter requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter = null;
            
             // populate IamIdentityCenter
            var requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenterIsNull = true;
            requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter = new Amazon.MPA.Model.IamIdentityCenter();
            System.String requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_InstanceArn = null;
            if (cmdletContext.IamIdentityCenter_InstanceArn != null)
            {
                requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_InstanceArn = cmdletContext.IamIdentityCenter_InstanceArn;
            }
            if (requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_InstanceArn != null)
            {
                requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter.InstanceArn = requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_InstanceArn;
                requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenterIsNull = false;
            }
            System.String requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_Region = null;
            if (cmdletContext.IamIdentityCenter_Region != null)
            {
                requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_Region = cmdletContext.IamIdentityCenter_Region;
            }
            if (requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_Region != null)
            {
                requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter.Region = requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter_iamIdentityCenter_Region;
                requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenterIsNull = false;
            }
             // determine if requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter should be set to null
            if (requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenterIsNull)
            {
                requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter = null;
            }
            if (requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter != null)
            {
                request.IdentitySourceParameters.IamIdentityCenter = requestIdentitySourceParameters_identitySourceParameters_IamIdentityCenter;
                requestIdentitySourceParametersIsNull = false;
            }
             // determine if request.IdentitySourceParameters should be set to null
            if (requestIdentitySourceParametersIsNull)
            {
                request.IdentitySourceParameters = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MPA.Model.CreateIdentitySourceResponse CallAWSServiceOperation(IAmazonMPA client, Amazon.MPA.Model.CreateIdentitySourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Multi-party Approval", "CreateIdentitySource");
            try
            {
                return client.CreateIdentitySourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String IamIdentityCenter_InstanceArn { get; set; }
            public System.String IamIdentityCenter_Region { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MPA.Model.CreateIdentitySourceResponse, NewMPAIdentitySourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
