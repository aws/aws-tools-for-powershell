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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Creates a new session.
    /// </summary>
    [Cmdlet("New", "GLUESession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.Session")]
    [AWSCmdlet("Calls the AWS Glue CreateSession API operation.", Operation = new[] {"CreateSession"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateSessionResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.Session or Amazon.Glue.Model.CreateSessionResponse",
        "This cmdlet returns an Amazon.Glue.Model.Session object.",
        "The service call response (type Amazon.Glue.Model.CreateSessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUESessionCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Connections_Connection
        /// <summary>
        /// <para>
        /// <para>A list of connections used by the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Connections_Connections")]
        public System.String[] Connections_Connection { get; set; }
        #endregion
        
        #region Parameter DefaultArgument
        /// <summary>
        /// <para>
        /// <para>A map array of key-value pairs. Max is 75 pairs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultArguments")]
        public System.Collections.Hashtable DefaultArgument { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the session. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter GlueVersion
        /// <summary>
        /// <para>
        /// <para>The Glue version determines the versions of Apache Spark and Python that Glue supports.
        /// The GlueVersion must be greater than 2.0. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlueVersion { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the session request. </para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter IdleTimeout
        /// <summary>
        /// <para>
        /// <para> The number of minutes when idle before session times out. Default for Spark ETL jobs
        /// is value of Timeout. Consult the documentation for other job types. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IdleTimeout { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The number of Glue data processing units (DPUs) that can be allocated when the job
        /// runs. A DPU is a relative measure of processing power that consists of 4 vCPUs of
        /// compute capacity and 16 GB memory. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter Command_Name
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the SessionCommand. Can be 'glueetl' or 'gluestreaming'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Command_Name { get; set; }
        #endregion
        
        #region Parameter NumberOfWorker
        /// <summary>
        /// <para>
        /// <para>The number of workers of a defined <c>WorkerType</c> to use for the session. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfWorkers")]
        public System.Int32? NumberOfWorker { get; set; }
        #endregion
        
        #region Parameter Command_PythonVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the Python version. The Python version indicates the version supported for
        /// jobs of type Spark.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Command_PythonVersion { get; set; }
        #endregion
        
        #region Parameter RequestOrigin
        /// <summary>
        /// <para>
        /// <para>The origin of the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestOrigin { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The IAM Role ARN </para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter SecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the SecurityConfiguration structure to be used with the session </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The map of key value pairs (tags) belonging to the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para> The number of minutes before session times out. Default for Spark ETL jobs is 48
        /// hours (2880 minutes), the maximum session lifetime for this job type. Consult the
        /// documentation for other job types. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter WorkerType
        /// <summary>
        /// <para>
        /// <para>The type of predefined worker that is allocated when a job runs. Accepts a value of
        /// G.1X, G.2X, G.4X, or G.8X for Spark jobs. Accepts the value Z.2X for Ray notebooks.</para><ul><li><para>For the <c>G.1X</c> worker type, each worker maps to 1 DPU (4 vCPUs, 16 GB of memory)
        /// with 84GB disk (approximately 34GB free), and provides 1 executor per worker. We recommend
        /// this worker type for workloads such as data transforms, joins, and queries, to offers
        /// a scalable and cost effective way to run most jobs.</para></li><li><para>For the <c>G.2X</c> worker type, each worker maps to 2 DPU (8 vCPUs, 32 GB of memory)
        /// with 128GB disk (approximately 77GB free), and provides 1 executor per worker. We
        /// recommend this worker type for workloads such as data transforms, joins, and queries,
        /// to offers a scalable and cost effective way to run most jobs.</para></li><li><para>For the <c>G.4X</c> worker type, each worker maps to 4 DPU (16 vCPUs, 64 GB of memory)
        /// with 256GB disk (approximately 235GB free), and provides 1 executor per worker. We
        /// recommend this worker type for jobs whose workloads contain your most demanding transforms,
        /// aggregations, joins, and queries. This worker type is available only for Glue version
        /// 3.0 or later Spark ETL jobs in the following Amazon Web Services Regions: US East
        /// (Ohio), US East (N. Virginia), US West (Oregon), Asia Pacific (Singapore), Asia Pacific
        /// (Sydney), Asia Pacific (Tokyo), Canada (Central), Europe (Frankfurt), Europe (Ireland),
        /// and Europe (Stockholm).</para></li><li><para>For the <c>G.8X</c> worker type, each worker maps to 8 DPU (32 vCPUs, 128 GB of memory)
        /// with 512GB disk (approximately 487GB free), and provides 1 executor per worker. We
        /// recommend this worker type for jobs whose workloads contain your most demanding transforms,
        /// aggregations, joins, and queries. This worker type is available only for Glue version
        /// 3.0 or later Spark ETL jobs, in the same Amazon Web Services Regions as supported
        /// for the <c>G.4X</c> worker type.</para></li><li><para>For the <c>Z.2X</c> worker type, each worker maps to 2 M-DPU (8vCPUs, 64 GB of memory)
        /// with 128 GB disk (approximately 120GB free), and provides up to 8 Ray workers based
        /// on the autoscaler.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.WorkerType")]
        public Amazon.Glue.WorkerType WorkerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Session'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateSessionResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Session";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUESession (CreateSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateSessionResponse, NewGLUESessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Command_Name = this.Command_Name;
            context.Command_PythonVersion = this.Command_PythonVersion;
            if (this.Connections_Connection != null)
            {
                context.Connections_Connection = new List<System.String>(this.Connections_Connection);
            }
            if (this.DefaultArgument != null)
            {
                context.DefaultArgument = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DefaultArgument.Keys)
                {
                    context.DefaultArgument.Add((String)hashKey, (System.String)(this.DefaultArgument[hashKey]));
                }
            }
            context.Description = this.Description;
            context.GlueVersion = this.GlueVersion;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdleTimeout = this.IdleTimeout;
            context.MaxCapacity = this.MaxCapacity;
            context.NumberOfWorker = this.NumberOfWorker;
            context.RequestOrigin = this.RequestOrigin;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityConfiguration = this.SecurityConfiguration;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Timeout = this.Timeout;
            context.WorkerType = this.WorkerType;
            
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
            var request = new Amazon.Glue.Model.CreateSessionRequest();
            
            
             // populate Command
            var requestCommandIsNull = true;
            request.Command = new Amazon.Glue.Model.SessionCommand();
            System.String requestCommand_command_Name = null;
            if (cmdletContext.Command_Name != null)
            {
                requestCommand_command_Name = cmdletContext.Command_Name;
            }
            if (requestCommand_command_Name != null)
            {
                request.Command.Name = requestCommand_command_Name;
                requestCommandIsNull = false;
            }
            System.String requestCommand_command_PythonVersion = null;
            if (cmdletContext.Command_PythonVersion != null)
            {
                requestCommand_command_PythonVersion = cmdletContext.Command_PythonVersion;
            }
            if (requestCommand_command_PythonVersion != null)
            {
                request.Command.PythonVersion = requestCommand_command_PythonVersion;
                requestCommandIsNull = false;
            }
             // determine if request.Command should be set to null
            if (requestCommandIsNull)
            {
                request.Command = null;
            }
            
             // populate Connections
            var requestConnectionsIsNull = true;
            request.Connections = new Amazon.Glue.Model.ConnectionsList();
            List<System.String> requestConnections_connections_Connection = null;
            if (cmdletContext.Connections_Connection != null)
            {
                requestConnections_connections_Connection = cmdletContext.Connections_Connection;
            }
            if (requestConnections_connections_Connection != null)
            {
                request.Connections.Connections = requestConnections_connections_Connection;
                requestConnectionsIsNull = false;
            }
             // determine if request.Connections should be set to null
            if (requestConnectionsIsNull)
            {
                request.Connections = null;
            }
            if (cmdletContext.DefaultArgument != null)
            {
                request.DefaultArguments = cmdletContext.DefaultArgument;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.GlueVersion != null)
            {
                request.GlueVersion = cmdletContext.GlueVersion;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IdleTimeout != null)
            {
                request.IdleTimeout = cmdletContext.IdleTimeout.Value;
            }
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.NumberOfWorker != null)
            {
                request.NumberOfWorkers = cmdletContext.NumberOfWorker.Value;
            }
            if (cmdletContext.RequestOrigin != null)
            {
                request.RequestOrigin = cmdletContext.RequestOrigin;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.SecurityConfiguration != null)
            {
                request.SecurityConfiguration = cmdletContext.SecurityConfiguration;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            if (cmdletContext.WorkerType != null)
            {
                request.WorkerType = cmdletContext.WorkerType;
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
        
        private Amazon.Glue.Model.CreateSessionResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateSession");
            try
            {
                #if DESKTOP
                return client.CreateSession(request);
                #elif CORECLR
                return client.CreateSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String Command_Name { get; set; }
            public System.String Command_PythonVersion { get; set; }
            public List<System.String> Connections_Connection { get; set; }
            public Dictionary<System.String, System.String> DefaultArgument { get; set; }
            public System.String Description { get; set; }
            public System.String GlueVersion { get; set; }
            public System.String Id { get; set; }
            public System.Int32? IdleTimeout { get; set; }
            public System.Double? MaxCapacity { get; set; }
            public System.Int32? NumberOfWorker { get; set; }
            public System.String RequestOrigin { get; set; }
            public System.String Role { get; set; }
            public System.String SecurityConfiguration { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Timeout { get; set; }
            public Amazon.Glue.WorkerType WorkerType { get; set; }
            public System.Func<Amazon.Glue.Model.CreateSessionResponse, NewGLUESessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Session;
        }
        
    }
}
