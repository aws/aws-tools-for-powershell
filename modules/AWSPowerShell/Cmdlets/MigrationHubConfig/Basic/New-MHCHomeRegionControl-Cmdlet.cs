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
using Amazon.MigrationHubConfig;
using Amazon.MigrationHubConfig.Model;

namespace Amazon.PowerShell.Cmdlets.MHC
{
    /// <summary>
    /// This API sets up the home region for the calling account only.
    /// </summary>
    [Cmdlet("New", "MHCHomeRegionControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MigrationHubConfig.Model.HomeRegionControl")]
    [AWSCmdlet("Calls the AWS Migration Hub Config CreateHomeRegionControl API operation.", Operation = new[] {"CreateHomeRegionControl"}, SelectReturnType = typeof(Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubConfig.Model.HomeRegionControl or Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse",
        "This cmdlet returns an Amazon.MigrationHubConfig.Model.HomeRegionControl object.",
        "The service call response (type Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMHCHomeRegionControlCmdlet : AmazonMigrationHubConfigClientCmdlet, IExecutor
    {
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Optional Boolean flag to indicate whether any effect should take place. It tests whether
        /// the caller has permission to make the call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter HomeRegion
        /// <summary>
        /// <para>
        /// <para>The name of the home region of the calling account.</para>
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
        public System.String HomeRegion { get; set; }
        #endregion
        
        #region Parameter Target_Id
        /// <summary>
        /// <para>
        /// <para>The <code>TargetID</code> is a 12-character identifier of the <code>ACCOUNT</code>
        /// for which the control was created. (This must be the current account.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Target_Id { get; set; }
        #endregion
        
        #region Parameter Target_Type
        /// <summary>
        /// <para>
        /// <para>The target type is always an <code>ACCOUNT</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MigrationHubConfig.TargetType")]
        public Amazon.MigrationHubConfig.TargetType Target_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HomeRegionControl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HomeRegionControl";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HomeRegion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HomeRegion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HomeRegion' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Target_Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MHCHomeRegionControl (CreateHomeRegionControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse, NewMHCHomeRegionControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HomeRegion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DryRun = this.DryRun;
            context.HomeRegion = this.HomeRegion;
            #if MODULAR
            if (this.HomeRegion == null && ParameterWasBound(nameof(this.HomeRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter HomeRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Target_Id = this.Target_Id;
            context.Target_Type = this.Target_Type;
            #if MODULAR
            if (this.Target_Type == null && ParameterWasBound(nameof(this.Target_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Target_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MigrationHubConfig.Model.CreateHomeRegionControlRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.HomeRegion != null)
            {
                request.HomeRegion = cmdletContext.HomeRegion;
            }
            
             // populate Target
            var requestTargetIsNull = true;
            request.Target = new Amazon.MigrationHubConfig.Model.Target();
            System.String requestTarget_target_Id = null;
            if (cmdletContext.Target_Id != null)
            {
                requestTarget_target_Id = cmdletContext.Target_Id;
            }
            if (requestTarget_target_Id != null)
            {
                request.Target.Id = requestTarget_target_Id;
                requestTargetIsNull = false;
            }
            Amazon.MigrationHubConfig.TargetType requestTarget_target_Type = null;
            if (cmdletContext.Target_Type != null)
            {
                requestTarget_target_Type = cmdletContext.Target_Type;
            }
            if (requestTarget_target_Type != null)
            {
                request.Target.Type = requestTarget_target_Type;
                requestTargetIsNull = false;
            }
             // determine if request.Target should be set to null
            if (requestTargetIsNull)
            {
                request.Target = null;
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
        
        private Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse CallAWSServiceOperation(IAmazonMigrationHubConfig client, Amazon.MigrationHubConfig.Model.CreateHomeRegionControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Config", "CreateHomeRegionControl");
            try
            {
                #if DESKTOP
                return client.CreateHomeRegionControl(request);
                #elif CORECLR
                return client.CreateHomeRegionControlAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String HomeRegion { get; set; }
            public System.String Target_Id { get; set; }
            public Amazon.MigrationHubConfig.TargetType Target_Type { get; set; }
            public System.Func<Amazon.MigrationHubConfig.Model.CreateHomeRegionControlResponse, NewMHCHomeRegionControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HomeRegionControl;
        }
        
    }
}
