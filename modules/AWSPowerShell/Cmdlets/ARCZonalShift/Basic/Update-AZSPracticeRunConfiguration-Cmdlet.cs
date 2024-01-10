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
using Amazon.ARCZonalShift;
using Amazon.ARCZonalShift.Model;

namespace Amazon.PowerShell.Cmdlets.AZS
{
    /// <summary>
    /// Update a practice run configuration to change one or more of the following: add, change,
    /// or remove the blocking alarm; change the outcome alarm; or add, change, or remove
    /// blocking dates or time windows.
    /// </summary>
    [Cmdlet("Update", "AZSPracticeRunConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift UpdatePracticeRunConfiguration API operation.", Operation = new[] {"UpdatePracticeRunConfiguration"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAZSPracticeRunConfigurationCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BlockedDate
        /// <summary>
        /// <para>
        /// <para>Add, change, or remove blocked dates for a practice run in zonal autoshift.</para><para>Optionally, you can block practice runs for specific calendar dates. The format for
        /// blocked dates is: YYYY-MM-DD. Keep in mind, when you specify dates, that dates and
        /// times for practice runs are in UTC. Separate multiple blocked dates with spaces.</para><para>For example, if you have an application update scheduled to launch on May 1, 2024,
        /// and you don't want practice runs to shift traffic away at that time, you could set
        /// a blocked date for <c>2024-05-01</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockedDates")]
        public System.String[] BlockedDate { get; set; }
        #endregion
        
        #region Parameter BlockedWindow
        /// <summary>
        /// <para>
        /// <para>Add, change, or remove windows of days and times for when you can, optionally, block
        /// Route 53 ARC from starting a practice run for a resource.</para><para>The format for blocked windows is: DAY:HH:SS-DAY:HH:SS. Keep in mind, when you specify
        /// dates, that dates and times for practice runs are in UTC. Also, be aware of potential
        /// time adjustments that might be required for daylight saving time differences. Separate
        /// multiple blocked windows with spaces.</para><para>For example, say you run business report summaries three days a week. For this scenario,
        /// you might set the following recurring days and times as blocked windows, for example:
        /// <c>MON-20:30-21:30 WED-20:30-21:30 FRI-20:30-21:30</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockedWindows")]
        public System.String[] BlockedWindow { get; set; }
        #endregion
        
        #region Parameter BlockingAlarm
        /// <summary>
        /// <para>
        /// <para>Add, change, or remove the Amazon CloudWatch alarm that you optionally specify as
        /// the blocking alarm for practice runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockingAlarms")]
        public Amazon.ARCZonalShift.Model.ControlCondition[] BlockingAlarm { get; set; }
        #endregion
        
        #region Parameter OutcomeAlarm
        /// <summary>
        /// <para>
        /// <para>Specify a new the Amazon CloudWatch alarm as the outcome alarm for practice runs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutcomeAlarms")]
        public Amazon.ARCZonalShift.Model.ControlCondition[] OutcomeAlarm { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the resource that you want to update the practice run configuration
        /// for. The identifier is the Amazon Resource Name (ARN) for the resource.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AZSPracticeRunConfiguration (UpdatePracticeRunConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse, UpdateAZSPracticeRunConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BlockedDate != null)
            {
                context.BlockedDate = new List<System.String>(this.BlockedDate);
            }
            if (this.BlockedWindow != null)
            {
                context.BlockedWindow = new List<System.String>(this.BlockedWindow);
            }
            if (this.BlockingAlarm != null)
            {
                context.BlockingAlarm = new List<Amazon.ARCZonalShift.Model.ControlCondition>(this.BlockingAlarm);
            }
            if (this.OutcomeAlarm != null)
            {
                context.OutcomeAlarm = new List<Amazon.ARCZonalShift.Model.ControlCondition>(this.OutcomeAlarm);
            }
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationRequest();
            
            if (cmdletContext.BlockedDate != null)
            {
                request.BlockedDates = cmdletContext.BlockedDate;
            }
            if (cmdletContext.BlockedWindow != null)
            {
                request.BlockedWindows = cmdletContext.BlockedWindow;
            }
            if (cmdletContext.BlockingAlarm != null)
            {
                request.BlockingAlarms = cmdletContext.BlockingAlarm;
            }
            if (cmdletContext.OutcomeAlarm != null)
            {
                request.OutcomeAlarms = cmdletContext.OutcomeAlarm;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
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
        
        private Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "UpdatePracticeRunConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdatePracticeRunConfiguration(request);
                #elif CORECLR
                return client.UpdatePracticeRunConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> BlockedDate { get; set; }
            public List<System.String> BlockedWindow { get; set; }
            public List<Amazon.ARCZonalShift.Model.ControlCondition> BlockingAlarm { get; set; }
            public List<Amazon.ARCZonalShift.Model.ControlCondition> OutcomeAlarm { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.UpdatePracticeRunConfigurationResponse, UpdateAZSPracticeRunConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
