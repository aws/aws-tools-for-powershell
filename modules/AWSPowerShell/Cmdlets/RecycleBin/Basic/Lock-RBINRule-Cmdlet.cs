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
using Amazon.RecycleBin;
using Amazon.RecycleBin.Model;

namespace Amazon.PowerShell.Cmdlets.RBIN
{
    /// <summary>
    /// Locks a retention rule. A locked retention rule can't be modified or deleted.
    /// </summary>
    [Cmdlet("Lock", "RBINRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RecycleBin.Model.LockRuleResponse")]
    [AWSCmdlet("Calls the Amazon Recycle Bin LockRule API operation.", Operation = new[] {"LockRule"}, SelectReturnType = typeof(Amazon.RecycleBin.Model.LockRuleResponse))]
    [AWSCmdletOutput("Amazon.RecycleBin.Model.LockRuleResponse",
        "This cmdlet returns an Amazon.RecycleBin.Model.LockRuleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class LockRBINRuleCmdlet : AmazonRecycleBinClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique ID of the retention rule.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter UnlockDelay_UnlockDelayUnit
        /// <summary>
        /// <para>
        /// <para>The unit of time in which to measure the unlock delay. Currently, the unlock delay
        /// can be measure only in days.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LockConfiguration_UnlockDelay_UnlockDelayUnit")]
        [AWSConstantClassSource("Amazon.RecycleBin.UnlockDelayUnit")]
        public Amazon.RecycleBin.UnlockDelayUnit UnlockDelay_UnlockDelayUnit { get; set; }
        #endregion
        
        #region Parameter UnlockDelay_UnlockDelayValue
        /// <summary>
        /// <para>
        /// <para>The unlock delay period, measured in the unit specified for <b> UnlockDelayUnit</b>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LockConfiguration_UnlockDelay_UnlockDelayValue")]
        public System.Int32? UnlockDelay_UnlockDelayValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RecycleBin.Model.LockRuleResponse).
        /// Specifying the name of a property of type Amazon.RecycleBin.Model.LockRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Lock-RBINRule (LockRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RecycleBin.Model.LockRuleResponse, LockRBINRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UnlockDelay_UnlockDelayUnit = this.UnlockDelay_UnlockDelayUnit;
            #if MODULAR
            if (this.UnlockDelay_UnlockDelayUnit == null && ParameterWasBound(nameof(this.UnlockDelay_UnlockDelayUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter UnlockDelay_UnlockDelayUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UnlockDelay_UnlockDelayValue = this.UnlockDelay_UnlockDelayValue;
            #if MODULAR
            if (this.UnlockDelay_UnlockDelayValue == null && ParameterWasBound(nameof(this.UnlockDelay_UnlockDelayValue)))
            {
                WriteWarning("You are passing $null as a value for parameter UnlockDelay_UnlockDelayValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RecycleBin.Model.LockRuleRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            
             // populate LockConfiguration
            var requestLockConfigurationIsNull = true;
            request.LockConfiguration = new Amazon.RecycleBin.Model.LockConfiguration();
            Amazon.RecycleBin.Model.UnlockDelay requestLockConfiguration_lockConfiguration_UnlockDelay = null;
            
             // populate UnlockDelay
            var requestLockConfiguration_lockConfiguration_UnlockDelayIsNull = true;
            requestLockConfiguration_lockConfiguration_UnlockDelay = new Amazon.RecycleBin.Model.UnlockDelay();
            Amazon.RecycleBin.UnlockDelayUnit requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit = null;
            if (cmdletContext.UnlockDelay_UnlockDelayUnit != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit = cmdletContext.UnlockDelay_UnlockDelayUnit;
            }
            if (requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay.UnlockDelayUnit = requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit;
                requestLockConfiguration_lockConfiguration_UnlockDelayIsNull = false;
            }
            System.Int32? requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue = null;
            if (cmdletContext.UnlockDelay_UnlockDelayValue != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue = cmdletContext.UnlockDelay_UnlockDelayValue.Value;
            }
            if (requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay.UnlockDelayValue = requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue.Value;
                requestLockConfiguration_lockConfiguration_UnlockDelayIsNull = false;
            }
             // determine if requestLockConfiguration_lockConfiguration_UnlockDelay should be set to null
            if (requestLockConfiguration_lockConfiguration_UnlockDelayIsNull)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay = null;
            }
            if (requestLockConfiguration_lockConfiguration_UnlockDelay != null)
            {
                request.LockConfiguration.UnlockDelay = requestLockConfiguration_lockConfiguration_UnlockDelay;
                requestLockConfigurationIsNull = false;
            }
             // determine if request.LockConfiguration should be set to null
            if (requestLockConfigurationIsNull)
            {
                request.LockConfiguration = null;
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
        
        private Amazon.RecycleBin.Model.LockRuleResponse CallAWSServiceOperation(IAmazonRecycleBin client, Amazon.RecycleBin.Model.LockRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Recycle Bin", "LockRule");
            try
            {
                #if DESKTOP
                return client.LockRule(request);
                #elif CORECLR
                return client.LockRuleAsync(request).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public Amazon.RecycleBin.UnlockDelayUnit UnlockDelay_UnlockDelayUnit { get; set; }
            public System.Int32? UnlockDelay_UnlockDelayValue { get; set; }
            public System.Func<Amazon.RecycleBin.Model.LockRuleResponse, LockRBINRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
