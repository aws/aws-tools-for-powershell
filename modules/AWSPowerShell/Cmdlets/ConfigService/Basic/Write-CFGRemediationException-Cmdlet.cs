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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// A remediation exception is when a specific resource is no longer considered for auto-remediation.
    /// This API adds a new exception or updates an existing exception for a specific resource
    /// with a specific Config rule. 
    /// 
    ///  <note><para>
    /// Config generates a remediation exception when a problem occurs executing a remediation
    /// action to a specific resource. Remediation exceptions blocks auto-remediation until
    /// the exception is cleared.
    /// </para></note><note><para>
    /// To place an exception on an Amazon Web Services resource, ensure remediation is set
    /// as manual remediation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGRemediationException", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.FailedRemediationExceptionBatch")]
    [AWSCmdlet("Calls the AWS Config PutRemediationExceptions API operation.", Operation = new[] {"PutRemediationExceptions"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutRemediationExceptionsResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.FailedRemediationExceptionBatch or Amazon.ConfigService.Model.PutRemediationExceptionsResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.FailedRemediationExceptionBatch objects.",
        "The service call response (type Amazon.ConfigService.Model.PutRemediationExceptionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGRemediationExceptionCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The name of the Config rule for which you want to create remediation exception.</para>
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
        public System.String ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter ExpirationTime
        /// <summary>
        /// <para>
        /// <para>The exception is automatically deleted after the expiration date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpirationTime { get; set; }
        #endregion
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The message contains an explanation of the exception.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Message { get; set; }
        #endregion
        
        #region Parameter ResourceKey
        /// <summary>
        /// <para>
        /// <para>An exception list of resource exception keys to be processed with the current request.
        /// Config adds exception for each resource key. For example, Config adds 3 exceptions
        /// for 3 resource keys. </para>
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
        [Alias("ResourceKeys")]
        public Amazon.ConfigService.Model.RemediationExceptionResourceKey[] ResourceKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedBatches'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutRemediationExceptionsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutRemediationExceptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedBatches";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigRuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigRuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigRuleName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigRuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGRemediationException (PutRemediationExceptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutRemediationExceptionsResponse, WriteCFGRemediationExceptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigRuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigRuleName = this.ConfigRuleName;
            #if MODULAR
            if (this.ConfigRuleName == null && ParameterWasBound(nameof(this.ConfigRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpirationTime = this.ExpirationTime;
            context.Message = this.Message;
            if (this.ResourceKey != null)
            {
                context.ResourceKey = new List<Amazon.ConfigService.Model.RemediationExceptionResourceKey>(this.ResourceKey);
            }
            #if MODULAR
            if (this.ResourceKey == null && ParameterWasBound(nameof(this.ResourceKey)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ConfigService.Model.PutRemediationExceptionsRequest();
            
            if (cmdletContext.ConfigRuleName != null)
            {
                request.ConfigRuleName = cmdletContext.ConfigRuleName;
            }
            if (cmdletContext.ExpirationTime != null)
            {
                request.ExpirationTime = cmdletContext.ExpirationTime.Value;
            }
            if (cmdletContext.Message != null)
            {
                request.Message = cmdletContext.Message;
            }
            if (cmdletContext.ResourceKey != null)
            {
                request.ResourceKeys = cmdletContext.ResourceKey;
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
        
        private Amazon.ConfigService.Model.PutRemediationExceptionsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutRemediationExceptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutRemediationExceptions");
            try
            {
                #if DESKTOP
                return client.PutRemediationExceptions(request);
                #elif CORECLR
                return client.PutRemediationExceptionsAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigRuleName { get; set; }
            public System.DateTime? ExpirationTime { get; set; }
            public System.String Message { get; set; }
            public List<Amazon.ConfigService.Model.RemediationExceptionResourceKey> ResourceKey { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutRemediationExceptionsResponse, WriteCFGRemediationExceptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedBatches;
        }
        
    }
}
