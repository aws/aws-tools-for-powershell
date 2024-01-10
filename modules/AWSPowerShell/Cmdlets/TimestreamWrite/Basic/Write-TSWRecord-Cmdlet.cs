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
using Amazon.TimestreamWrite;
using Amazon.TimestreamWrite.Model;

namespace Amazon.PowerShell.Cmdlets.TSW
{
    /// <summary>
    /// Enables you to write your time-series data into Timestream. You can specify a single
    /// data point or a batch of data points to be inserted into the system. Timestream offers
    /// you a flexible schema that auto detects the column names and data types for your Timestream
    /// tables based on the dimension names and data types of the data points you specify
    /// when invoking writes into the database. 
    /// 
    ///  
    /// <para>
    /// Timestream supports eventual consistency read semantics. This means that when you
    /// query data immediately after writing a batch of data into Timestream, the query results
    /// might not reflect the results of a recently completed write operation. The results
    /// may also include some stale data. If you repeat the query request after a short time,
    /// the results should return the latest data. <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/ts-limits.html">Service
    /// quotas apply</a>. 
    /// </para><para>
    /// See <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/code-samples.write.html">code
    /// sample</a> for details.
    /// </para><para><b>Upserts</b></para><para>
    /// You can use the <c>Version</c> parameter in a <c>WriteRecords</c> request to update
    /// data points. Timestream tracks a version number with each record. <c>Version</c> defaults
    /// to <c>1</c> when it's not specified for the record in the request. Timestream updates
    /// an existing record’s measure value along with its <c>Version</c> when it receives
    /// a write request with a higher <c>Version</c> number for that record. When it receives
    /// an update request where the measure value is the same as that of the existing record,
    /// Timestream still updates <c>Version</c>, if it is greater than the existing value
    /// of <c>Version</c>. You can update a data point as many times as desired, as long as
    /// the value of <c>Version</c> continuously increases. 
    /// </para><para>
    ///  For example, suppose you write a new record without indicating <c>Version</c> in
    /// the request. Timestream stores this record, and set <c>Version</c> to <c>1</c>. Now,
    /// suppose you try to update this record with a <c>WriteRecords</c> request of the same
    /// record with a different measure value but, like before, do not provide <c>Version</c>.
    /// In this case, Timestream will reject this update with a <c>RejectedRecordsException</c>
    /// since the updated record’s version is not greater than the existing value of Version.
    /// 
    /// </para><para>
    /// However, if you were to resend the update request with <c>Version</c> set to <c>2</c>,
    /// Timestream would then succeed in updating the record’s value, and the <c>Version</c>
    /// would be set to <c>2</c>. Next, suppose you sent a <c>WriteRecords</c> request with
    /// this same record and an identical measure value, but with <c>Version</c> set to <c>3</c>.
    /// In this case, Timestream would only update <c>Version</c> to <c>3</c>. Any further
    /// updates would need to send a version number greater than <c>3</c>, or the update requests
    /// would receive a <c>RejectedRecordsException</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "TSWRecord", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamWrite.Model.WriteRecordsResponse")]
    [AWSCmdlet("Calls the Amazon Timestream Write WriteRecords API operation.", Operation = new[] {"WriteRecords"}, SelectReturnType = typeof(Amazon.TimestreamWrite.Model.WriteRecordsResponse))]
    [AWSCmdletOutput("Amazon.TimestreamWrite.Model.WriteRecordsResponse",
        "This cmdlet returns an Amazon.TimestreamWrite.Model.WriteRecordsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteTSWRecordCmdlet : AmazonTimestreamWriteClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the Timestream database.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_Dimension
        /// <summary>
        /// <para>
        /// <para>Contains the list of dimensions for time-series data points.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommonAttributes_Dimensions")]
        public Amazon.TimestreamWrite.Model.Dimension[] CommonAttributes_Dimension { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_MeasureName
        /// <summary>
        /// <para>
        /// <para>Measure represents the data attribute of the time series. For example, the CPU utilization
        /// of an EC2 instance or the RPM of a wind turbine are measures. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommonAttributes_MeasureName { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_MeasureValue
        /// <summary>
        /// <para>
        /// <para> Contains the measure value for the time-series data point. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommonAttributes_MeasureValue { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_MeasureValueList
        /// <summary>
        /// <para>
        /// <para> Contains the list of MeasureValue for time-series data points. </para><para> This is only allowed for type <c>MULTI</c>. For scalar values, use <c>MeasureValue</c>
        /// attribute of the record directly. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.TimestreamWrite.Model.MeasureValue[] CommonAttributes_MeasureValueList { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_MeasureValueType
        /// <summary>
        /// <para>
        /// <para> Contains the data type of the measure value for the time-series data point. Default
        /// type is <c>DOUBLE</c>. For more information, see <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/writes.html#writes.data-types">Data
        /// types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamWrite.MeasureValueType")]
        public Amazon.TimestreamWrite.MeasureValueType CommonAttributes_MeasureValueType { get; set; }
        #endregion
        
        #region Parameter Record
        /// <summary>
        /// <para>
        /// <para>An array of records that contain the unique measure, dimension, time, and version
        /// attributes for each time-series data point. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Records")]
        public Amazon.TimestreamWrite.Model.Record[] Record { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the Timestream table.</para>
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
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_Time
        /// <summary>
        /// <para>
        /// <para> Contains the time at which the measure value for the data point was collected. The
        /// time value plus the unit provides the time elapsed since the epoch. For example, if
        /// the time value is <c>12345</c> and the unit is <c>ms</c>, then <c>12345 ms</c> have
        /// elapsed since the epoch. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CommonAttributes_Time { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_TimeUnit
        /// <summary>
        /// <para>
        /// <para> The granularity of the timestamp unit. It indicates if the time value is in seconds,
        /// milliseconds, nanoseconds, or other supported values. Default is <c>MILLISECONDS</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.TimestreamWrite.TimeUnit")]
        public Amazon.TimestreamWrite.TimeUnit CommonAttributes_TimeUnit { get; set; }
        #endregion
        
        #region Parameter CommonAttributes_Version
        /// <summary>
        /// <para>
        /// <para>64-bit attribute used for record updates. Write requests for duplicate data with a
        /// higher version number will update the existing measure value and version. In cases
        /// where the measure value is the same, <c>Version</c> will still be updated. Default
        /// value is <c>1</c>.</para><note><para><c>Version</c> must be <c>1</c> or greater, or you will receive a <c>ValidationException</c>
        /// error.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CommonAttributes_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamWrite.Model.WriteRecordsResponse).
        /// Specifying the name of a property of type Amazon.TimestreamWrite.Model.WriteRecordsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Record parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Record' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Record' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-TSWRecord (WriteRecords)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamWrite.Model.WriteRecordsResponse, WriteTSWRecordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Record;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CommonAttributes_Dimension != null)
            {
                context.CommonAttributes_Dimension = new List<Amazon.TimestreamWrite.Model.Dimension>(this.CommonAttributes_Dimension);
            }
            context.CommonAttributes_MeasureName = this.CommonAttributes_MeasureName;
            context.CommonAttributes_MeasureValue = this.CommonAttributes_MeasureValue;
            if (this.CommonAttributes_MeasureValueList != null)
            {
                context.CommonAttributes_MeasureValueList = new List<Amazon.TimestreamWrite.Model.MeasureValue>(this.CommonAttributes_MeasureValueList);
            }
            context.CommonAttributes_MeasureValueType = this.CommonAttributes_MeasureValueType;
            context.CommonAttributes_Time = this.CommonAttributes_Time;
            context.CommonAttributes_TimeUnit = this.CommonAttributes_TimeUnit;
            context.CommonAttributes_Version = this.CommonAttributes_Version;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Record != null)
            {
                context.Record = new List<Amazon.TimestreamWrite.Model.Record>(this.Record);
            }
            #if MODULAR
            if (this.Record == null && ParameterWasBound(nameof(this.Record)))
            {
                WriteWarning("You are passing $null as a value for parameter Record which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TimestreamWrite.Model.WriteRecordsRequest();
            
            
             // populate CommonAttributes
            var requestCommonAttributesIsNull = true;
            request.CommonAttributes = new Amazon.TimestreamWrite.Model.Record();
            List<Amazon.TimestreamWrite.Model.Dimension> requestCommonAttributes_commonAttributes_Dimension = null;
            if (cmdletContext.CommonAttributes_Dimension != null)
            {
                requestCommonAttributes_commonAttributes_Dimension = cmdletContext.CommonAttributes_Dimension;
            }
            if (requestCommonAttributes_commonAttributes_Dimension != null)
            {
                request.CommonAttributes.Dimensions = requestCommonAttributes_commonAttributes_Dimension;
                requestCommonAttributesIsNull = false;
            }
            System.String requestCommonAttributes_commonAttributes_MeasureName = null;
            if (cmdletContext.CommonAttributes_MeasureName != null)
            {
                requestCommonAttributes_commonAttributes_MeasureName = cmdletContext.CommonAttributes_MeasureName;
            }
            if (requestCommonAttributes_commonAttributes_MeasureName != null)
            {
                request.CommonAttributes.MeasureName = requestCommonAttributes_commonAttributes_MeasureName;
                requestCommonAttributesIsNull = false;
            }
            System.String requestCommonAttributes_commonAttributes_MeasureValue = null;
            if (cmdletContext.CommonAttributes_MeasureValue != null)
            {
                requestCommonAttributes_commonAttributes_MeasureValue = cmdletContext.CommonAttributes_MeasureValue;
            }
            if (requestCommonAttributes_commonAttributes_MeasureValue != null)
            {
                request.CommonAttributes.MeasureValue = requestCommonAttributes_commonAttributes_MeasureValue;
                requestCommonAttributesIsNull = false;
            }
            List<Amazon.TimestreamWrite.Model.MeasureValue> requestCommonAttributes_commonAttributes_MeasureValueList = null;
            if (cmdletContext.CommonAttributes_MeasureValueList != null)
            {
                requestCommonAttributes_commonAttributes_MeasureValueList = cmdletContext.CommonAttributes_MeasureValueList;
            }
            if (requestCommonAttributes_commonAttributes_MeasureValueList != null)
            {
                request.CommonAttributes.MeasureValues = requestCommonAttributes_commonAttributes_MeasureValueList;
                requestCommonAttributesIsNull = false;
            }
            Amazon.TimestreamWrite.MeasureValueType requestCommonAttributes_commonAttributes_MeasureValueType = null;
            if (cmdletContext.CommonAttributes_MeasureValueType != null)
            {
                requestCommonAttributes_commonAttributes_MeasureValueType = cmdletContext.CommonAttributes_MeasureValueType;
            }
            if (requestCommonAttributes_commonAttributes_MeasureValueType != null)
            {
                request.CommonAttributes.MeasureValueType = requestCommonAttributes_commonAttributes_MeasureValueType;
                requestCommonAttributesIsNull = false;
            }
            System.String requestCommonAttributes_commonAttributes_Time = null;
            if (cmdletContext.CommonAttributes_Time != null)
            {
                requestCommonAttributes_commonAttributes_Time = cmdletContext.CommonAttributes_Time;
            }
            if (requestCommonAttributes_commonAttributes_Time != null)
            {
                request.CommonAttributes.Time = requestCommonAttributes_commonAttributes_Time;
                requestCommonAttributesIsNull = false;
            }
            Amazon.TimestreamWrite.TimeUnit requestCommonAttributes_commonAttributes_TimeUnit = null;
            if (cmdletContext.CommonAttributes_TimeUnit != null)
            {
                requestCommonAttributes_commonAttributes_TimeUnit = cmdletContext.CommonAttributes_TimeUnit;
            }
            if (requestCommonAttributes_commonAttributes_TimeUnit != null)
            {
                request.CommonAttributes.TimeUnit = requestCommonAttributes_commonAttributes_TimeUnit;
                requestCommonAttributesIsNull = false;
            }
            System.Int64? requestCommonAttributes_commonAttributes_Version = null;
            if (cmdletContext.CommonAttributes_Version != null)
            {
                requestCommonAttributes_commonAttributes_Version = cmdletContext.CommonAttributes_Version.Value;
            }
            if (requestCommonAttributes_commonAttributes_Version != null)
            {
                request.CommonAttributes.Version = requestCommonAttributes_commonAttributes_Version.Value;
                requestCommonAttributesIsNull = false;
            }
             // determine if request.CommonAttributes should be set to null
            if (requestCommonAttributesIsNull)
            {
                request.CommonAttributes = null;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.Record != null)
            {
                request.Records = cmdletContext.Record;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
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
        
        private Amazon.TimestreamWrite.Model.WriteRecordsResponse CallAWSServiceOperation(IAmazonTimestreamWrite client, Amazon.TimestreamWrite.Model.WriteRecordsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Write", "WriteRecords");
            try
            {
                #if DESKTOP
                return client.WriteRecords(request);
                #elif CORECLR
                return client.WriteRecordsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.TimestreamWrite.Model.Dimension> CommonAttributes_Dimension { get; set; }
            public System.String CommonAttributes_MeasureName { get; set; }
            public System.String CommonAttributes_MeasureValue { get; set; }
            public List<Amazon.TimestreamWrite.Model.MeasureValue> CommonAttributes_MeasureValueList { get; set; }
            public Amazon.TimestreamWrite.MeasureValueType CommonAttributes_MeasureValueType { get; set; }
            public System.String CommonAttributes_Time { get; set; }
            public Amazon.TimestreamWrite.TimeUnit CommonAttributes_TimeUnit { get; set; }
            public System.Int64? CommonAttributes_Version { get; set; }
            public System.String DatabaseName { get; set; }
            public List<Amazon.TimestreamWrite.Model.Record> Record { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.TimestreamWrite.Model.WriteRecordsResponse, WriteTSWRecordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
