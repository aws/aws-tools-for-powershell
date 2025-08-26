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
using Amazon.ARCZonalShift;
using Amazon.ARCZonalShift.Model;

namespace Amazon.PowerShell.Cmdlets.AZS
{
    /// <summary>
    /// A practice run configuration for zonal autoshift is required when you enable zonal
    /// autoshift. A practice run configuration includes specifications for blocked dates
    /// and blocked time windows, and for Amazon CloudWatch alarms that you create to use
    /// with practice runs. The alarms that you specify are an <i>outcome alarm</i>, to monitor
    /// application health during practice runs and, optionally, a <i>blocking alarm</i>,
    /// to block practice runs from starting.
    /// 
    ///  
    /// <para>
    /// When a resource has a practice run configuration, ARC starts zonal shifts for the
    /// resource weekly, to shift traffic for practice runs. Practice runs help you to ensure
    /// that shifting away traffic from an Availability Zone during an autoshift is safe for
    /// your application.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/arc-zonal-autoshift.considerations.html">
    /// Considerations when you configure zonal autoshift</a> in the Amazon Application Recovery
    /// Controller Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("New", "AZSPracticeRunConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse")]
    [AWSCmdlet("Calls the AWS ARC - Zonal Shift CreatePracticeRunConfiguration API operation.", Operation = new[] {"CreatePracticeRunConfiguration"}, SelectReturnType = typeof(Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse",
        "This cmdlet returns an Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse object containing multiple properties."
    )]
    public partial class NewAZSPracticeRunConfigurationCmdlet : AmazonARCZonalShiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowedWindow
        /// <summary>
        /// <para>
        /// <para>Optionally, you can allow ARC to start practice runs for specific windows of days
        /// and times. </para><para>The format for allowed windows is: DAY:HH:SS-DAY:HH:SS. Keep in mind, when you specify
        /// dates, that dates and times for practice runs are in UTC. Also, be aware of potential
        /// time adjustments that might be required for daylight saving time differences. Separate
        /// multiple allowed windows with spaces.</para><para>For example, say you want to allow practice runs only on Wednesdays and Fridays from
        /// noon to 5 p.m. For this scenario, you could set the following recurring days and times
        /// as allowed windows, for example: <c>Wed-12:00-Wed:17:00 Fri-12:00-Fri:17:00</c>.</para><important><para>The <c>allowedWindows</c> have to start and end on the same day. Windows that span
        /// multiple days aren't supported.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedWindows")]
        public System.String[] AllowedWindow { get; set; }
        #endregion
        
        #region Parameter BlockedDate
        /// <summary>
        /// <para>
        /// <para>Optionally, you can block ARC from starting practice runs for a resource on specific
        /// calendar dates.</para><para>The format for blocked dates is: YYYY-MM-DD. Keep in mind, when you specify dates,
        /// that dates and times for practice runs are in UTC. Separate multiple blocked dates
        /// with spaces.</para><para>For example, if you have an application update scheduled to launch on May 1, 2024,
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
        /// <para>Optionally, you can block ARC from starting practice runs for specific windows of
        /// days and times. </para><para>The format for blocked windows is: DAY:HH:SS-DAY:HH:SS. Keep in mind, when you specify
        /// dates, that dates and times for practice runs are in UTC. Also, be aware of potential
        /// time adjustments that might be required for daylight saving time differences. Separate
        /// multiple blocked windows with spaces.</para><para>For example, say you run business report summaries three days a week. For this scenario,
        /// you could set the following recurring days and times as blocked windows, for example:
        /// <c>Mon:00:00-Mon:10:00 Wed-20:30-Wed:21:30 Fri-20:30-Fri:21:30</c>.</para><important><para>The <c>blockedWindows</c> have to start and end on the same day. Windows that span
        /// multiple days aren't supported.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockedWindows")]
        public System.String[] BlockedWindow { get; set; }
        #endregion
        
        #region Parameter BlockingAlarm
        /// <summary>
        /// <para>
        /// <para><i>Blocking alarms</i> for practice runs are optional alarms that you can specify
        /// that block practice runs when one or more of the alarms is in an <c>ALARM</c> state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockingAlarms")]
        public Amazon.ARCZonalShift.Model.ControlCondition[] BlockingAlarm { get; set; }
        #endregion
        
        #region Parameter OutcomeAlarm
        /// <summary>
        /// <para>
        /// <para><i>Outcome alarms</i> for practice runs are alarms that you specify that end a practice
        /// run when one or more of the alarms is in an <c>ALARM</c> state.</para><para>Configure one or more of these alarms to monitor the health of your application when
        /// traffic is shifted away from an Availability Zone during each practice run. You should
        /// configure these alarms to go into an <c>ALARM</c> state if you want to stop a zonal
        /// shift, to let traffic for the resource return to the original Availability Zone.</para>
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
        [Alias("OutcomeAlarms")]
        public Amazon.ARCZonalShift.Model.ControlCondition[] OutcomeAlarm { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource that Amazon Web Services shifts traffic for with a
        /// practice run zonal shift. The identifier is the Amazon Resource Name (ARN) for the
        /// resource.</para><para>Amazon Application Recovery Controller currently supports enabling the following resources
        /// for zonal shift and zonal autoshift:</para><ul><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/arc-zonal-shift.resource-types.ec2-auto-scaling-groups.html">Amazon
        /// EC2 Auto Scaling groups</a></para></li><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/arc-zonal-shift.resource-types.eks.html">Amazon
        /// Elastic Kubernetes Service</a></para></li><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/arc-zonal-shift.resource-types.app-load-balancers.html">Application
        /// Load Balancer</a></para></li><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/arc-zonal-shift.resource-types.network-load-balancers.html">Network
        /// Load Balancer</a></para></li></ul>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AZSPracticeRunConfiguration (CreatePracticeRunConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse, NewAZSPracticeRunConfigurationCmdlet>(Select) ??
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
            if (this.AllowedWindow != null)
            {
                context.AllowedWindow = new List<System.String>(this.AllowedWindow);
            }
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
            #if MODULAR
            if (this.OutcomeAlarm == null && ParameterWasBound(nameof(this.OutcomeAlarm)))
            {
                WriteWarning("You are passing $null as a value for parameter OutcomeAlarm which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationRequest();
            
            if (cmdletContext.AllowedWindow != null)
            {
                request.AllowedWindows = cmdletContext.AllowedWindow;
            }
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
        
        private Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse CallAWSServiceOperation(IAmazonARCZonalShift client, Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS ARC - Zonal Shift", "CreatePracticeRunConfiguration");
            try
            {
                #if DESKTOP
                return client.CreatePracticeRunConfiguration(request);
                #elif CORECLR
                return client.CreatePracticeRunConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedWindow { get; set; }
            public List<System.String> BlockedDate { get; set; }
            public List<System.String> BlockedWindow { get; set; }
            public List<Amazon.ARCZonalShift.Model.ControlCondition> BlockingAlarm { get; set; }
            public List<Amazon.ARCZonalShift.Model.ControlCondition> OutcomeAlarm { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.Func<Amazon.ARCZonalShift.Model.CreatePracticeRunConfigurationResponse, NewAZSPracticeRunConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
