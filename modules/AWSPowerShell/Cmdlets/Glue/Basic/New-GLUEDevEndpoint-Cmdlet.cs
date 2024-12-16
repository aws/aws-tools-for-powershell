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
    /// Creates a new development endpoint.
    /// </summary>
    [Cmdlet("New", "GLUEDevEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.CreateDevEndpointResponse")]
    [AWSCmdlet("Calls the AWS Glue CreateDevEndpoint API operation.", Operation = new[] {"CreateDevEndpoint"}, SelectReturnType = typeof(Amazon.Glue.Model.CreateDevEndpointResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.CreateDevEndpointResponse",
        "This cmdlet returns an Amazon.Glue.Model.CreateDevEndpointResponse object containing multiple properties."
    )]
    public partial class NewGLUEDevEndpointCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Argument
        /// <summary>
        /// <para>
        /// <para>A map of arguments used to configure the <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Arguments")]
        public System.Collections.Hashtable Argument { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name to be assigned to the new <c>DevEndpoint</c>.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter ExtraJarsS3Path
        /// <summary>
        /// <para>
        /// <para>The path to one or more Java <c>.jar</c> files in an S3 bucket that should be loaded
        /// in your <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtraJarsS3Path { get; set; }
        #endregion
        
        #region Parameter ExtraPythonLibsS3Path
        /// <summary>
        /// <para>
        /// <para>The paths to one or more Python libraries in an Amazon S3 bucket that should be loaded
        /// in your <c>DevEndpoint</c>. Multiple values must be complete paths separated by a
        /// comma.</para><note><para>You can only use pure Python libraries with a <c>DevEndpoint</c>. Libraries that rely
        /// on C extensions, such as the <a href="http://pandas.pydata.org/">pandas</a> Python
        /// data analysis library, are not yet supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtraPythonLibsS3Path { get; set; }
        #endregion
        
        #region Parameter GlueVersion
        /// <summary>
        /// <para>
        /// <para>Glue version determines the versions of Apache Spark and Python that Glue supports.
        /// The Python version indicates the version supported for running your ETL scripts on
        /// development endpoints. </para><para>For more information about the available Glue versions and corresponding Spark and
        /// Python versions, see <a href="https://docs.aws.amazon.com/glue/latest/dg/add-job.html">Glue
        /// version</a> in the developer guide.</para><para>Development endpoints that are created without specifying a Glue version default to
        /// Glue 0.9.</para><para>You can specify a version of Python support for development endpoints by using the
        /// <c>Arguments</c> parameter in the <c>CreateDevEndpoint</c> or <c>UpdateDevEndpoint</c>
        /// APIs. If no arguments are provided, the version defaults to Python 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GlueVersion { get; set; }
        #endregion
        
        #region Parameter NumberOfNode
        /// <summary>
        /// <para>
        /// <para>The number of Glue Data Processing Units (DPUs) to allocate to this <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfNodes")]
        public System.Int32? NumberOfNode { get; set; }
        #endregion
        
        #region Parameter NumberOfWorker
        /// <summary>
        /// <para>
        /// <para>The number of workers of a defined <c>workerType</c> that are allocated to the development
        /// endpoint.</para><para>The maximum number of workers you can define are 299 for <c>G.1X</c>, and 149 for
        /// <c>G.2X</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfWorkers")]
        public System.Int32? NumberOfWorker { get; set; }
        #endregion
        
        #region Parameter PublicKey
        /// <summary>
        /// <para>
        /// <para>The public key to be used by this <c>DevEndpoint</c> for authentication. This attribute
        /// is provided for backward compatibility because the recommended attribute to use is
        /// public keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PublicKey { get; set; }
        #endregion
        
        #region Parameter PublicKeyList
        /// <summary>
        /// <para>
        /// <para>A list of public keys to be used by the development endpoints for authentication.
        /// The use of this attribute is preferred over a single public key because the public
        /// keys allow you to have a different private key per client.</para><note><para>If you previously created an endpoint with a public key, you must remove that key
        /// to be able to set a list of public keys. Call the <c>UpdateDevEndpoint</c> API with
        /// the public key content in the <c>deletePublicKeys</c> attribute, and the list of new
        /// keys in the <c>addPublicKeys</c> attribute.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] PublicKeyList { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role for the <c>DevEndpoint</c>.</para>
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
        
        #region Parameter SecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of the <c>SecurityConfiguration</c> structure to be used with this <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Security group IDs for the security groups to be used by the new <c>DevEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet ID for the new <c>DevEndpoint</c> to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to use with this DevEndpoint. You may use tags to limit access to the DevEndpoint.
        /// For more information about tags in Glue, see <a href="https://docs.aws.amazon.com/glue/latest/dg/monitor-tags.html">Amazon
        /// Web Services Tags in Glue</a> in the developer guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkerType
        /// <summary>
        /// <para>
        /// <para>The type of predefined worker that is allocated to the development endpoint. Accepts
        /// a value of Standard, G.1X, or G.2X.</para><ul><li><para>For the <c>Standard</c> worker type, each worker provides 4 vCPU, 16 GB of memory
        /// and a 50GB disk, and 2 executors per worker.</para></li><li><para>For the <c>G.1X</c> worker type, each worker maps to 1 DPU (4 vCPU, 16 GB of memory,
        /// 64 GB disk), and provides 1 executor per worker. We recommend this worker type for
        /// memory-intensive jobs.</para></li><li><para>For the <c>G.2X</c> worker type, each worker maps to 2 DPU (8 vCPU, 32 GB of memory,
        /// 128 GB disk), and provides 1 executor per worker. We recommend this worker type for
        /// memory-intensive jobs.</para></li></ul><para>Known issue: when a development endpoint is created with the <c>G.2X</c><c>WorkerType</c>
        /// configuration, the Spark drivers for the development endpoint will run on 4 vCPU,
        /// 16 GB of memory, and a 64 GB disk. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.WorkerType")]
        public Amazon.Glue.WorkerType WorkerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.CreateDevEndpointResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.CreateDevEndpointResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEDevEndpoint (CreateDevEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.CreateDevEndpointResponse, NewGLUEDevEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Argument != null)
            {
                context.Argument = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Argument.Keys)
                {
                    context.Argument.Add((String)hashKey, (System.String)(this.Argument[hashKey]));
                }
            }
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExtraJarsS3Path = this.ExtraJarsS3Path;
            context.ExtraPythonLibsS3Path = this.ExtraPythonLibsS3Path;
            context.GlueVersion = this.GlueVersion;
            context.NumberOfNode = this.NumberOfNode;
            context.NumberOfWorker = this.NumberOfWorker;
            context.PublicKey = this.PublicKey;
            if (this.PublicKeyList != null)
            {
                context.PublicKeyList = new List<System.String>(this.PublicKeyList);
            }
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityConfiguration = this.SecurityConfiguration;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.SubnetId = this.SubnetId;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.Glue.Model.CreateDevEndpointRequest();
            
            if (cmdletContext.Argument != null)
            {
                request.Arguments = cmdletContext.Argument;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.ExtraJarsS3Path != null)
            {
                request.ExtraJarsS3Path = cmdletContext.ExtraJarsS3Path;
            }
            if (cmdletContext.ExtraPythonLibsS3Path != null)
            {
                request.ExtraPythonLibsS3Path = cmdletContext.ExtraPythonLibsS3Path;
            }
            if (cmdletContext.GlueVersion != null)
            {
                request.GlueVersion = cmdletContext.GlueVersion;
            }
            if (cmdletContext.NumberOfNode != null)
            {
                request.NumberOfNodes = cmdletContext.NumberOfNode.Value;
            }
            if (cmdletContext.NumberOfWorker != null)
            {
                request.NumberOfWorkers = cmdletContext.NumberOfWorker.Value;
            }
            if (cmdletContext.PublicKey != null)
            {
                request.PublicKey = cmdletContext.PublicKey;
            }
            if (cmdletContext.PublicKeyList != null)
            {
                request.PublicKeys = cmdletContext.PublicKeyList;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SecurityConfiguration != null)
            {
                request.SecurityConfiguration = cmdletContext.SecurityConfiguration;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Glue.Model.CreateDevEndpointResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateDevEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateDevEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateDevEndpoint(request);
                #elif CORECLR
                return client.CreateDevEndpointAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Argument { get; set; }
            public System.String EndpointName { get; set; }
            public System.String ExtraJarsS3Path { get; set; }
            public System.String ExtraPythonLibsS3Path { get; set; }
            public System.String GlueVersion { get; set; }
            public System.Int32? NumberOfNode { get; set; }
            public System.Int32? NumberOfWorker { get; set; }
            public System.String PublicKey { get; set; }
            public List<System.String> PublicKeyList { get; set; }
            public System.String RoleArn { get; set; }
            public System.String SecurityConfiguration { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String SubnetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Glue.WorkerType WorkerType { get; set; }
            public System.Func<Amazon.Glue.Model.CreateDevEndpointResponse, NewGLUEDevEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
