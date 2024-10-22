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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Creates a journal stream for a given Amazon QLDB ledger. The stream captures every
    /// document revision that is committed to the ledger's journal and delivers the data
    /// to a specified Amazon Kinesis Data Streams resource.
    /// </summary>
    [Cmdlet("Start", "QLDBStreamJournalToKinesi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QLDB StreamJournalToKinesis API operation.", Operation = new[] {"StreamJournalToKinesis"}, SelectReturnType = typeof(Amazon.QLDB.Model.StreamJournalToKinesisResponse))]
    [AWSCmdletOutput("System.String or Amazon.QLDB.Model.StreamJournalToKinesisResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QLDB.Model.StreamJournalToKinesisResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartQLDBStreamJournalToKinesiCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KinesisConfiguration_AggregationEnabled
        /// <summary>
        /// <para>
        /// <para>Enables QLDB to publish multiple data records in a single Kinesis Data Streams record,
        /// increasing the number of records sent per API call.</para><para>Default: <c>True</c></para><important><para>Record aggregation has important implications for processing records and requires
        /// de-aggregation in your stream consumer. To learn more, see <a href="https://docs.aws.amazon.com/streams/latest/dev/kinesis-kpl-concepts.html">KPL
        /// Key Concepts</a> and <a href="https://docs.aws.amazon.com/streams/latest/dev/kinesis-kpl-consumer-deaggregation.html">Consumer
        /// De-aggregation</a> in the <i>Amazon Kinesis Data Streams Developer Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KinesisConfiguration_AggregationEnabled { get; set; }
        #endregion
        
        #region Parameter ExclusiveEndTime
        /// <summary>
        /// <para>
        /// <para>The exclusive date and time that specifies when the stream ends. If you don't define
        /// this parameter, the stream runs indefinitely until you cancel it.</para><para>The <c>ExclusiveEndTime</c> must be in <c>ISO 8601</c> date and time format and in
        /// Universal Coordinated Time (UTC). For example: <c>2019-06-13T21:36:34Z</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExclusiveEndTime { get; set; }
        #endregion
        
        #region Parameter InclusiveStartTime
        /// <summary>
        /// <para>
        /// <para>The inclusive start date and time from which to start streaming journal data. This
        /// parameter must be in <c>ISO 8601</c> date and time format and in Universal Coordinated
        /// Time (UTC). For example: <c>2019-06-13T21:36:34Z</c>.</para><para>The <c>InclusiveStartTime</c> cannot be in the future and must be before <c>ExclusiveEndTime</c>.</para><para>If you provide an <c>InclusiveStartTime</c> that is before the ledger's <c>CreationDateTime</c>,
        /// QLDB effectively defaults it to the ledger's <c>CreationDateTime</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? InclusiveStartTime { get; set; }
        #endregion
        
        #region Parameter LedgerName
        /// <summary>
        /// <para>
        /// <para>The name of the ledger.</para>
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
        public System.String LedgerName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that grants QLDB permissions for a
        /// journal stream to write data records to a Kinesis Data Streams resource.</para><para>To pass a role to QLDB when requesting a journal stream, you must have permissions
        /// to perform the <c>iam:PassRole</c> action on the IAM role resource. This is required
        /// for all journal stream requests.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter KinesisConfiguration_StreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Kinesis Data Streams resource.</para>
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
        public System.String KinesisConfiguration_StreamArn { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name that you want to assign to the QLDB journal stream. User-defined names can
        /// help identify and indicate the purpose of a stream.</para><para>Your stream name must be unique among other <i>active</i> streams for a given ledger.
        /// Stream names have the same naming constraints as ledger names, as defined in <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/limits.html#limits.naming">Quotas
        /// in Amazon QLDB</a> in the <i>Amazon QLDB Developer Guide</i>.</para>
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
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to add as tags to the stream that you want to create. Tag keys
        /// are case sensitive. Tag values are case sensitive and can be null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.StreamJournalToKinesisResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.StreamJournalToKinesisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LedgerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-QLDBStreamJournalToKinesi (StreamJournalToKinesis)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.StreamJournalToKinesisResponse, StartQLDBStreamJournalToKinesiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExclusiveEndTime = this.ExclusiveEndTime;
            context.InclusiveStartTime = this.InclusiveStartTime;
            #if MODULAR
            if (this.InclusiveStartTime == null && ParameterWasBound(nameof(this.InclusiveStartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter InclusiveStartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KinesisConfiguration_AggregationEnabled = this.KinesisConfiguration_AggregationEnabled;
            context.KinesisConfiguration_StreamArn = this.KinesisConfiguration_StreamArn;
            #if MODULAR
            if (this.KinesisConfiguration_StreamArn == null && ParameterWasBound(nameof(this.KinesisConfiguration_StreamArn)))
            {
                WriteWarning("You are passing $null as a value for parameter KinesisConfiguration_StreamArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LedgerName = this.LedgerName;
            #if MODULAR
            if (this.LedgerName == null && ParameterWasBound(nameof(this.LedgerName)))
            {
                WriteWarning("You are passing $null as a value for parameter LedgerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamName = this.StreamName;
            #if MODULAR
            if (this.StreamName == null && ParameterWasBound(nameof(this.StreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.QLDB.Model.StreamJournalToKinesisRequest();
            
            if (cmdletContext.ExclusiveEndTime != null)
            {
                request.ExclusiveEndTime = cmdletContext.ExclusiveEndTime.Value;
            }
            if (cmdletContext.InclusiveStartTime != null)
            {
                request.InclusiveStartTime = cmdletContext.InclusiveStartTime.Value;
            }
            
             // populate KinesisConfiguration
            var requestKinesisConfigurationIsNull = true;
            request.KinesisConfiguration = new Amazon.QLDB.Model.KinesisConfiguration();
            System.Boolean? requestKinesisConfiguration_kinesisConfiguration_AggregationEnabled = null;
            if (cmdletContext.KinesisConfiguration_AggregationEnabled != null)
            {
                requestKinesisConfiguration_kinesisConfiguration_AggregationEnabled = cmdletContext.KinesisConfiguration_AggregationEnabled.Value;
            }
            if (requestKinesisConfiguration_kinesisConfiguration_AggregationEnabled != null)
            {
                request.KinesisConfiguration.AggregationEnabled = requestKinesisConfiguration_kinesisConfiguration_AggregationEnabled.Value;
                requestKinesisConfigurationIsNull = false;
            }
            System.String requestKinesisConfiguration_kinesisConfiguration_StreamArn = null;
            if (cmdletContext.KinesisConfiguration_StreamArn != null)
            {
                requestKinesisConfiguration_kinesisConfiguration_StreamArn = cmdletContext.KinesisConfiguration_StreamArn;
            }
            if (requestKinesisConfiguration_kinesisConfiguration_StreamArn != null)
            {
                request.KinesisConfiguration.StreamArn = requestKinesisConfiguration_kinesisConfiguration_StreamArn;
                requestKinesisConfigurationIsNull = false;
            }
             // determine if request.KinesisConfiguration should be set to null
            if (requestKinesisConfigurationIsNull)
            {
                request.KinesisConfiguration = null;
            }
            if (cmdletContext.LedgerName != null)
            {
                request.LedgerName = cmdletContext.LedgerName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        private Amazon.QLDB.Model.StreamJournalToKinesisResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.StreamJournalToKinesisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "StreamJournalToKinesis");
            try
            {
                #if DESKTOP
                return client.StreamJournalToKinesis(request);
                #elif CORECLR
                return client.StreamJournalToKinesisAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? ExclusiveEndTime { get; set; }
            public System.DateTime? InclusiveStartTime { get; set; }
            public System.Boolean? KinesisConfiguration_AggregationEnabled { get; set; }
            public System.String KinesisConfiguration_StreamArn { get; set; }
            public System.String LedgerName { get; set; }
            public System.String RoleArn { get; set; }
            public System.String StreamName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.QLDB.Model.StreamJournalToKinesisResponse, StartQLDBStreamJournalToKinesiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamId;
        }
        
    }
}
