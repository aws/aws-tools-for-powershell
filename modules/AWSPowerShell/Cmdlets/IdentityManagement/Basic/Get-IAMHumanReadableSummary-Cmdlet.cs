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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Retrieves a human readable summary for a given entity. At this time, the only supported
    /// entity type is <c>delegation-request</c><para>
    /// This method uses a Large Language Model (LLM) to generate the summary.
    /// </para><para>
    ///  If a delegation request has no owner or owner account, <c>GetHumanReadableSummary</c>
    /// for that delegation request can be called by any account. If the owner account is
    /// assigned but there is no owner id, only identities within that owner account can call
    /// <c>GetHumanReadableSummary</c> for the delegation request to retrieve a summary of
    /// that request. Once the delegation request is fully owned, the owner of the request
    /// gets a default permission to get that delegation request. For more details, read <a href="">default permissions granted to delegation requests</a>. These rules are identical
    /// to <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_GetDelegationRequest.html">GetDelegationRequest</a>
    /// API behavior, such that a party who has permissions to call <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_GetDelegationRequest.html">GetDelegationRequest</a>
    /// for a given delegation request will always be able to retrieve the human readable
    /// summary for that request. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IAMHumanReadableSummary")]
    [OutputType("Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GetHumanReadableSummary API operation.", Operation = new[] {"GetHumanReadableSummary"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse object containing multiple properties."
    )]
    public partial class GetIAMHumanReadableSummaryCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EntityArn
        /// <summary>
        /// <para>
        /// <para>Arn of the entity to be summarized. At this time, the only supported entity type is
        /// <c>delegation-request</c></para>
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
        public System.String EntityArn { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>A string representing the locale to use for the summary generation. The supported
        /// locale strings are based on the <a href="/awsconsolehelpdocs/latest/gsg/change-language.html#supported-languages">
        /// Supported languages of the Amazon Web Services Management Console </a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EntityArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EntityArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EntityArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse, GetIAMHumanReadableSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EntityArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EntityArn = this.EntityArn;
            #if MODULAR
            if (this.EntityArn == null && ParameterWasBound(nameof(this.EntityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Locale = this.Locale;
            
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
            var request = new Amazon.IdentityManagement.Model.GetHumanReadableSummaryRequest();
            
            if (cmdletContext.EntityArn != null)
            {
                request.EntityArn = cmdletContext.EntityArn;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
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
        
        private Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GetHumanReadableSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GetHumanReadableSummary");
            try
            {
                #if DESKTOP
                return client.GetHumanReadableSummary(request);
                #elif CORECLR
                return client.GetHumanReadableSummaryAsync(request).GetAwaiter().GetResult();
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
            public System.String EntityArn { get; set; }
            public System.String Locale { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.GetHumanReadableSummaryResponse, GetIAMHumanReadableSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
