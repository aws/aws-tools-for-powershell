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
using Amazon.ElementalInference;
using Amazon.ElementalInference.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMI
{
    /// <summary>
    /// Creates a schedule action on a feed. A schedule action applies configuration changes
    /// to the feed at a time that you specify, in the same way as an UpdateFeed request.
    /// 
    /// 
    ///  
    /// <para>
    /// Elemental Inference validates the targets of the action when you create it.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EMIScheduleAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElementalInference.Model.CreateScheduleActionResponse")]
    [AWSCmdlet("Calls the AWS Elemental Inference CreateScheduleAction API operation.", Operation = new[] {"CreateScheduleAction"}, SelectReturnType = typeof(Amazon.ElementalInference.Model.CreateScheduleActionResponse))]
    [AWSCmdletOutput("Amazon.ElementalInference.Model.CreateScheduleActionResponse",
        "This cmdlet returns an Amazon.ElementalInference.Model.CreateScheduleActionResponse object containing multiple properties."
    )]
    public partial class NewEMIScheduleActionCmdlet : AmazonElementalInferenceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActionName
        /// <summary>
        /// <para>
        /// <para>A name for the schedule action. The name must be unique within the feed. You can reuse
        /// the name of an action that you deleted. </para>
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
        public System.String ActionName { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the feed that you want to add the schedule action to.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>Specifies the list of configuration changes that you want to make to the feed. Elemental
        /// Inference applies all the operations in an action together, in the order that you
        /// specify them. If any operation fails, Elemental Inference doesn't apply any of them.
        /// </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Operations")]
        public Amazon.ElementalInference.Model.ScheduleActionOperation[] Operation { get; set; }
        #endregion
        
        #region Parameter StartConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt
        /// <summary>
        /// <para>
        /// <para>The UTC time at which the action runs. Specify the time in whole seconds. For the
        /// range of times that you can specify, see the AWS Elemental Inference User Guide. </para><para>This time is approximate. The change can take a few minutes to take effect on the
        /// media that the feed is processing. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElementalInference.Model.CreateScheduleActionResponse).
        /// Specifying the name of a property of type Amazon.ElementalInference.Model.CreateScheduleActionResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Id),
                nameof(this.ActionName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMIScheduleAction (CreateScheduleAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElementalInference.Model.CreateScheduleActionResponse, NewEMIScheduleActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionName = this.ActionName;
            #if MODULAR
            if (this.ActionName == null && ParameterWasBound(nameof(this.ActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Operation != null)
            {
                context.Operation = new List<Amazon.ElementalInference.Model.ScheduleActionOperation>(this.Operation);
            }
            #if MODULAR
            if (this.Operation == null && ParameterWasBound(nameof(this.Operation)))
            {
                WriteWarning("You are passing $null as a value for parameter Operation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt = this.StartConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt;
            
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
            var request = new Amazon.ElementalInference.Model.CreateScheduleActionRequest();
            
            if (cmdletContext.ActionName != null)
            {
                request.ActionName = cmdletContext.ActionName;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Operation != null)
            {
                request.Operations = cmdletContext.Operation;
            }
            
             // populate StartConfiguration
            var requestStartConfigurationIsNull = true;
            request.StartConfiguration = new Amazon.ElementalInference.Model.ScheduleActionStartConfiguration();
            Amazon.ElementalInference.Model.FixedModeScheduleActionStartSettings requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings = null;
            
             // populate FixedModeScheduleActionStartSettings
            var requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettingsIsNull = true;
            requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings = new Amazon.ElementalInference.Model.FixedModeScheduleActionStartSettings();
            System.DateTime? requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings_startConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt = null;
            if (cmdletContext.StartConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt != null)
            {
                requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings_startConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt = cmdletContext.StartConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt.Value;
            }
            if (requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings_startConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt != null)
            {
                requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings.ScheduledAt = requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings_startConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt.Value;
                requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettingsIsNull = false;
            }
             // determine if requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings should be set to null
            if (requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettingsIsNull)
            {
                requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings = null;
            }
            if (requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings != null)
            {
                request.StartConfiguration.FixedModeScheduleActionStartSettings = requestStartConfiguration_startConfiguration_FixedModeScheduleActionStartSettings;
                requestStartConfigurationIsNull = false;
            }
             // determine if request.StartConfiguration should be set to null
            if (requestStartConfigurationIsNull)
            {
                request.StartConfiguration = null;
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
        
        private Amazon.ElementalInference.Model.CreateScheduleActionResponse CallAWSServiceOperation(IAmazonElementalInference client, Amazon.ElementalInference.Model.CreateScheduleActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental Inference", "CreateScheduleAction");
            try
            {
                return client.CreateScheduleActionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActionName { get; set; }
            public System.String Id { get; set; }
            public List<Amazon.ElementalInference.Model.ScheduleActionOperation> Operation { get; set; }
            public System.DateTime? StartConfiguration_FixedModeScheduleActionStartSettings_ScheduledAt { get; set; }
            public System.Func<Amazon.ElementalInference.Model.CreateScheduleActionResponse, NewEMIScheduleActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
