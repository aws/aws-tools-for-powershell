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
using Amazon.TimestreamInfluxDB;
using Amazon.TimestreamInfluxDB.Model;

namespace Amazon.PowerShell.Cmdlets.TIDB
{
    /// <summary>
    /// Creates a new Timestream for InfluxDB DB parameter group to associate with DB instances.
    /// </summary>
    [Cmdlet("New", "TIDBDbParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse")]
    [AWSCmdlet("Calls the Amazon Timestream InfluxDB CreateDbParameterGroup API operation.", Operation = new[] {"CreateDbParameterGroup"}, SelectReturnType = typeof(Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse",
        "This cmdlet returns an Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTIDBDbParameterGroupCmdlet : AmazonTimestreamInfluxDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_FluxLogEnabled
        /// <summary>
        /// <para>
        /// <para>Include option to show detailed logs for Flux queries.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_FluxLogEnabled")]
        public System.Boolean? InfluxDBv2_FluxLogEnabled { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_LogLevel
        /// <summary>
        /// <para>
        /// <para>Log output level. InfluxDB outputs log entries with severity levels greater than or
        /// equal to the level specified.</para><para>Default: info</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_LogLevel")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.LogLevel")]
        public Amazon.TimestreamInfluxDB.LogLevel InfluxDBv2_LogLevel { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_MetricsDisabled
        /// <summary>
        /// <para>
        /// <para>Disable the HTTP /metrics endpoint which exposes <a href="https://docs.influxdata.com/influxdb/v2/reference/internals/metrics/">internal
        /// InfluxDB metrics</a>.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_MetricsDisabled")]
        public System.Boolean? InfluxDBv2_MetricsDisabled { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the DB parameter group. The name must be unique per customer and per region.</para>
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
        
        #region Parameter InfluxDBv2_NoTask
        /// <summary>
        /// <para>
        /// <para>Disable the task scheduler. If problematic tasks prevent InfluxDB from starting, use
        /// this option to start InfluxDB without scheduling or executing tasks.</para><para>Default: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_NoTasks")]
        public System.Boolean? InfluxDBv2_NoTask { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_QueryConcurrency
        /// <summary>
        /// <para>
        /// <para>Number of queries allowed to execute concurrently. Setting to 0 allows an unlimited
        /// number of concurrent queries.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_QueryConcurrency")]
        public System.Int32? InfluxDBv2_QueryConcurrency { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_QueryQueueSize
        /// <summary>
        /// <para>
        /// <para>Maximum number of queries allowed in execution queue. When queue limit is reached,
        /// new queries are rejected. Setting to 0 allows an unlimited number of queries in the
        /// queue.</para><para>Default: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_QueryQueueSize")]
        public System.Int32? InfluxDBv2_QueryQueueSize { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the DB parameter group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter InfluxDBv2_TracingType
        /// <summary>
        /// <para>
        /// <para>Enable tracing in InfluxDB and specifies the tracing type. Tracing is disabled by
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters_InfluxDBv2_TracingType")]
        [AWSConstantClassSource("Amazon.TimestreamInfluxDB.TracingType")]
        public Amazon.TimestreamInfluxDB.TracingType InfluxDBv2_TracingType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TIDBDbParameterGroup (CreateDbParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse, NewTIDBDbParameterGroupCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InfluxDBv2_FluxLogEnabled = this.InfluxDBv2_FluxLogEnabled;
            context.InfluxDBv2_LogLevel = this.InfluxDBv2_LogLevel;
            context.InfluxDBv2_MetricsDisabled = this.InfluxDBv2_MetricsDisabled;
            context.InfluxDBv2_NoTask = this.InfluxDBv2_NoTask;
            context.InfluxDBv2_QueryConcurrency = this.InfluxDBv2_QueryConcurrency;
            context.InfluxDBv2_QueryQueueSize = this.InfluxDBv2_QueryQueueSize;
            context.InfluxDBv2_TracingType = this.InfluxDBv2_TracingType;
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
            var request = new Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Parameters
            var requestParametersIsNull = true;
            request.Parameters = new Amazon.TimestreamInfluxDB.Model.Parameters();
            Amazon.TimestreamInfluxDB.Model.InfluxDBv2Parameters requestParameters_parameters_InfluxDBv2 = null;
            
             // populate InfluxDBv2
            var requestParameters_parameters_InfluxDBv2IsNull = true;
            requestParameters_parameters_InfluxDBv2 = new Amazon.TimestreamInfluxDB.Model.InfluxDBv2Parameters();
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled = null;
            if (cmdletContext.InfluxDBv2_FluxLogEnabled != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled = cmdletContext.InfluxDBv2_FluxLogEnabled.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled != null)
            {
                requestParameters_parameters_InfluxDBv2.FluxLogEnabled = requestParameters_parameters_InfluxDBv2_influxDBv2_FluxLogEnabled.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.LogLevel requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel = null;
            if (cmdletContext.InfluxDBv2_LogLevel != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel = cmdletContext.InfluxDBv2_LogLevel;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel != null)
            {
                requestParameters_parameters_InfluxDBv2.LogLevel = requestParameters_parameters_InfluxDBv2_influxDBv2_LogLevel;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled = null;
            if (cmdletContext.InfluxDBv2_MetricsDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled = cmdletContext.InfluxDBv2_MetricsDisabled.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled != null)
            {
                requestParameters_parameters_InfluxDBv2.MetricsDisabled = requestParameters_parameters_InfluxDBv2_influxDBv2_MetricsDisabled.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Boolean? requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask = null;
            if (cmdletContext.InfluxDBv2_NoTask != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask = cmdletContext.InfluxDBv2_NoTask.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask != null)
            {
                requestParameters_parameters_InfluxDBv2.NoTasks = requestParameters_parameters_InfluxDBv2_influxDBv2_NoTask.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency = null;
            if (cmdletContext.InfluxDBv2_QueryConcurrency != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency = cmdletContext.InfluxDBv2_QueryConcurrency.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency != null)
            {
                requestParameters_parameters_InfluxDBv2.QueryConcurrency = requestParameters_parameters_InfluxDBv2_influxDBv2_QueryConcurrency.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            System.Int32? requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize = null;
            if (cmdletContext.InfluxDBv2_QueryQueueSize != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize = cmdletContext.InfluxDBv2_QueryQueueSize.Value;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize != null)
            {
                requestParameters_parameters_InfluxDBv2.QueryQueueSize = requestParameters_parameters_InfluxDBv2_influxDBv2_QueryQueueSize.Value;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
            Amazon.TimestreamInfluxDB.TracingType requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType = null;
            if (cmdletContext.InfluxDBv2_TracingType != null)
            {
                requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType = cmdletContext.InfluxDBv2_TracingType;
            }
            if (requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType != null)
            {
                requestParameters_parameters_InfluxDBv2.TracingType = requestParameters_parameters_InfluxDBv2_influxDBv2_TracingType;
                requestParameters_parameters_InfluxDBv2IsNull = false;
            }
             // determine if requestParameters_parameters_InfluxDBv2 should be set to null
            if (requestParameters_parameters_InfluxDBv2IsNull)
            {
                requestParameters_parameters_InfluxDBv2 = null;
            }
            if (requestParameters_parameters_InfluxDBv2 != null)
            {
                request.Parameters.InfluxDBv2 = requestParameters_parameters_InfluxDBv2;
                requestParametersIsNull = false;
            }
             // determine if request.Parameters should be set to null
            if (requestParametersIsNull)
            {
                request.Parameters = null;
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
        
        private Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse CallAWSServiceOperation(IAmazonTimestreamInfluxDB client, Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream InfluxDB", "CreateDbParameterGroup");
            try
            {
                #if DESKTOP
                return client.CreateDbParameterGroup(request);
                #elif CORECLR
                return client.CreateDbParameterGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? InfluxDBv2_FluxLogEnabled { get; set; }
            public Amazon.TimestreamInfluxDB.LogLevel InfluxDBv2_LogLevel { get; set; }
            public System.Boolean? InfluxDBv2_MetricsDisabled { get; set; }
            public System.Boolean? InfluxDBv2_NoTask { get; set; }
            public System.Int32? InfluxDBv2_QueryConcurrency { get; set; }
            public System.Int32? InfluxDBv2_QueryQueueSize { get; set; }
            public Amazon.TimestreamInfluxDB.TracingType InfluxDBv2_TracingType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.TimestreamInfluxDB.Model.CreateDbParameterGroupResponse, NewTIDBDbParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
