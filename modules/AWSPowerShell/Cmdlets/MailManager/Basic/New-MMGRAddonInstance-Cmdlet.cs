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
using Amazon.MailManager;
using Amazon.MailManager.Model;

namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Creates an Add On instance for the subscription indicated in the request. The resulting
    /// Amazon Resource Name (ARN) can be used in a conditional statement for a rule set or
    /// traffic policy.
    /// </summary>
    [Cmdlet("New", "MMGRAddonInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager CreateAddonInstance API operation.", Operation = new[] {"CreateAddonInstance"}, SelectReturnType = typeof(Amazon.MailManager.Model.CreateAddonInstanceResponse))]
    [AWSCmdletOutput("System.String or Amazon.MailManager.Model.CreateAddonInstanceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.MailManager.Model.CreateAddonInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMMGRAddonInstanceCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AddonSubscriptionId
        /// <summary>
        /// <para>
        /// <para>The unique ID of a previously created subscription that an Add On instance is created
        /// for. You can only have one instance per subscription.</para>
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
        public System.String AddonSubscriptionId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for the resource. For example,
        /// { "tags": {"key1":"value1", "key2":"value2"} }.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MailManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that Amazon SES uses to recognize subsequent retries of the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AddonInstanceId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.CreateAddonInstanceResponse).
        /// Specifying the name of a property of type Amazon.MailManager.Model.CreateAddonInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AddonInstanceId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AddonSubscriptionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AddonSubscriptionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AddonSubscriptionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AddonSubscriptionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MMGRAddonInstance (CreateAddonInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.CreateAddonInstanceResponse, NewMMGRAddonInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AddonSubscriptionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AddonSubscriptionId = this.AddonSubscriptionId;
            #if MODULAR
            if (this.AddonSubscriptionId == null && ParameterWasBound(nameof(this.AddonSubscriptionId)))
            {
                WriteWarning("You are passing $null as a value for parameter AddonSubscriptionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MailManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.MailManager.Model.CreateAddonInstanceRequest();
            
            if (cmdletContext.AddonSubscriptionId != null)
            {
                request.AddonSubscriptionId = cmdletContext.AddonSubscriptionId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
        
        private Amazon.MailManager.Model.CreateAddonInstanceResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.CreateAddonInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "CreateAddonInstance");
            try
            {
                #if DESKTOP
                return client.CreateAddonInstance(request);
                #elif CORECLR
                return client.CreateAddonInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String AddonSubscriptionId { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.MailManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.MailManager.Model.CreateAddonInstanceResponse, NewMMGRAddonInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AddonInstanceId;
        }
        
    }
}
