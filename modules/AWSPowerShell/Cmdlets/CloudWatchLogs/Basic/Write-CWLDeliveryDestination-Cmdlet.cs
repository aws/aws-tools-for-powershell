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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates or updates a logical <i>delivery destination</i>. A delivery destination is
    /// an Amazon Web Services resource that represents an Amazon Web Services service that
    /// logs can be sent to. CloudWatch Logs, Amazon S3, and Kinesis Data Firehose are supported
    /// as logs delivery destinations.
    /// 
    ///  
    /// <para>
    /// To configure logs delivery between a supported Amazon Web Services service and a destination,
    /// you must do the following:
    /// </para><ul><li><para>
    /// Create a delivery source, which is a logical object that represents the resource that
    /// is actually sending the logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliverySource.html">PutDeliverySource</a>.
    /// </para></li><li><para>
    /// Use <code>PutDeliveryDestination</code> to create a <i>delivery destination</i>, which
    /// is a logical object that represents the actual delivery destination. 
    /// </para></li><li><para>
    /// If you are delivering logs cross-account, you must use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDeliveryDestinationolicy.html">PutDeliveryDestinationPolicy</a>
    /// in the destination account to assign an IAM policy to the destination. This policy
    /// allows delivery to that destination. 
    /// </para></li><li><para>
    /// Use <code>CreateDelivery</code> to create a <i>delivery</i> by pairing exactly one
    /// delivery source and one delivery destination. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_CreateDelivery.html">CreateDelivery</a>.
    /// 
    /// </para></li></ul><para>
    /// You can configure a single delivery source to send logs to multiple destinations by
    /// creating multiple deliveries. You can also create multiple deliveries to configure
    /// multiple delivery sources to send logs to the same delivery destination.
    /// </para><para>
    /// Only some Amazon Web Services services support being configured as a delivery source.
    /// These services are listed as <b>Supported [V2 Permissions]</b> in the table at <a href="https://docs.aws.amazon.com/ AmazonCloudWatch/latest/logs/AWS-logs-and-resource-policy.html#AWS-vended-logs-permissions">Enabling
    /// logging from Amazon Web Services services.</a></para><para>
    /// If you use this operation to update an existing delivery destination, all the current
    /// delivery destination parameters are overwritten with the new parameter values that
    /// you specify.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLDeliveryDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.DeliveryDestination")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutDeliveryDestination API operation.", Operation = new[] {"PutDeliveryDestination"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.DeliveryDestination or Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.DeliveryDestination object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWLDeliveryDestinationCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeliveryDestinationConfiguration_DestinationResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services destination that this delivery destination represents.
        /// That Amazon Web Services destination can be a log group in CloudWatch Logs, an Amazon
        /// S3 bucket, or a delivery stream in Kinesis Data Firehose.</para>
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
        public System.String DeliveryDestinationConfiguration_DestinationResourceArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for this delivery destination. This name must be unique for all delivery destinations
        /// in your account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>The format for the logs that this delivery destination will receive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.OutputFormat")]
        public Amazon.CloudWatchLogs.OutputFormat OutputFormat { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of key-value pairs to associate with the resource.</para><para>For more information about tagging, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeliveryDestination'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeliveryDestination";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLDeliveryDestination (PutDeliveryDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse, WriteCWLDeliveryDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeliveryDestinationConfiguration_DestinationResourceArn = this.DeliveryDestinationConfiguration_DestinationResourceArn;
            #if MODULAR
            if (this.DeliveryDestinationConfiguration_DestinationResourceArn == null && ParameterWasBound(nameof(this.DeliveryDestinationConfiguration_DestinationResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryDestinationConfiguration_DestinationResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputFormat = this.OutputFormat;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.CloudWatchLogs.Model.PutDeliveryDestinationRequest();
            
            
             // populate DeliveryDestinationConfiguration
            var requestDeliveryDestinationConfigurationIsNull = true;
            request.DeliveryDestinationConfiguration = new Amazon.CloudWatchLogs.Model.DeliveryDestinationConfiguration();
            System.String requestDeliveryDestinationConfiguration_deliveryDestinationConfiguration_DestinationResourceArn = null;
            if (cmdletContext.DeliveryDestinationConfiguration_DestinationResourceArn != null)
            {
                requestDeliveryDestinationConfiguration_deliveryDestinationConfiguration_DestinationResourceArn = cmdletContext.DeliveryDestinationConfiguration_DestinationResourceArn;
            }
            if (requestDeliveryDestinationConfiguration_deliveryDestinationConfiguration_DestinationResourceArn != null)
            {
                request.DeliveryDestinationConfiguration.DestinationResourceArn = requestDeliveryDestinationConfiguration_deliveryDestinationConfiguration_DestinationResourceArn;
                requestDeliveryDestinationConfigurationIsNull = false;
            }
             // determine if request.DeliveryDestinationConfiguration should be set to null
            if (requestDeliveryDestinationConfigurationIsNull)
            {
                request.DeliveryDestinationConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
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
        
        private Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutDeliveryDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutDeliveryDestination");
            try
            {
                #if DESKTOP
                return client.PutDeliveryDestination(request);
                #elif CORECLR
                return client.PutDeliveryDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String DeliveryDestinationConfiguration_DestinationResourceArn { get; set; }
            public System.String Name { get; set; }
            public Amazon.CloudWatchLogs.OutputFormat OutputFormat { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutDeliveryDestinationResponse, WriteCWLDeliveryDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeliveryDestination;
        }
        
    }
}
