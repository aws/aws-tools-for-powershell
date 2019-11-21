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
using Amazon.AppMesh;
using Amazon.AppMesh.Model;

namespace Amazon.PowerShell.Cmdlets.AMSH
{
    /// <summary>
    /// Creates a virtual node within a service mesh.
    /// 
    ///          
    /// <para>
    /// A virtual node acts as a logical pointer to a particular task group, such as an Amazon
    /// ECS         service or a Kubernetes deployment. When you create a virtual node, you
    /// can specify the         service discovery information for your task group.
    /// </para><para>
    /// Any inbound traffic that your virtual node expects should be specified as a      
    ///      <code>listener</code>. Any outbound traffic that your virtual node expects to
    /// reach         should be specified as a <code>backend</code>.
    /// </para><para>
    /// The response metadata for your new virtual node contains the <code>arn</code> that
    /// is         associated with the virtual node. Set this value (either the full ARN or
    /// the truncated         resource name: for example, <code>mesh/default/virtualNode/simpleapp</code>)
    /// as the            <code>APPMESH_VIRTUAL_NODE_NAME</code> environment variable for
    /// your task group's Envoy         proxy container in your task definition or pod spec.
    /// This is then mapped to the            <code>node.id</code> and <code>node.cluster</code>
    /// Envoy parameters.
    /// </para><note><para>
    /// If you require your Envoy stats or tracing to use a different name, you can override
    ///            the <code>node.cluster</code> value that is set by               <code>APPMESH_VIRTUAL_NODE_NAME</code>
    /// with the               <code>APPMESH_VIRTUAL_NODE_CLUSTER</code> environment variable.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "AMSHVirtualNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.VirtualNodeData")]
    [AWSCmdlet("Calls the AWS App Mesh CreateVirtualNode API operation.", Operation = new[] {"CreateVirtualNode"}, SelectReturnType = typeof(Amazon.AppMesh.Model.CreateVirtualNodeResponse))]
    [AWSCmdletOutput("Amazon.AppMesh.Model.VirtualNodeData or Amazon.AppMesh.Model.CreateVirtualNodeResponse",
        "This cmdlet returns an Amazon.AppMesh.Model.VirtualNodeData object.",
        "The service call response (type Amazon.AppMesh.Model.CreateVirtualNodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMSHVirtualNodeCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        #region Parameter AwsCloudMap_Attribute
        /// <summary>
        /// <para>
        /// <para>A string map that contains attributes with values that you can use to filter instances
        ///         by any custom attribute that you specified when you registered the instance.
        /// Only instances         that match all of the specified key/value pairs will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_AwsCloudMap_Attributes")]
        public Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute[] AwsCloudMap_Attribute { get; set; }
        #endregion
        
        #region Parameter Spec_Backend
        /// <summary>
        /// <para>
        /// <para>The backends that the virtual node is expected to send outbound traffic to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Backends")]
        public Amazon.AppMesh.Model.Backend[] Spec_Backend { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of therequest.
        /// Up to 36 letters, numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Dns_Hostname
        /// <summary>
        /// <para>
        /// <para>Specifies the DNS service discovery hostname for the virtual node. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_Dns_Hostname")]
        public System.String Dns_Hostname { get; set; }
        #endregion
        
        #region Parameter Spec_Listener
        /// <summary>
        /// <para>
        /// <para>The listeners that the virtual node is expected to receive inbound traffic from. 
        ///        You can specify one listener.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Listeners")]
        public Amazon.AppMesh.Model.Listener[] Spec_Listener { get; set; }
        #endregion
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh to create the virtual node in.</para>
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
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter AwsCloudMap_NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS Cloud Map namespace to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_AwsCloudMap_NamespaceName")]
        public System.String AwsCloudMap_NamespaceName { get; set; }
        #endregion
        
        #region Parameter File_Path
        /// <summary>
        /// <para>
        /// <para>The file path to write access logs to. You can use <code>/dev/stdout</code> to send
        ///         access logs to standard out and configure your Envoy container to use a log
        /// driver, such as            <code>awslogs</code>, to export the access logs to a log
        /// storage service such as Amazon         CloudWatch Logs. You can also specify a path
        /// in the Envoy container's file system to write         the files to disk.</para><note><para>The Envoy process must have write permissions to the path that you specify here. 
        ///           Otherwise, Envoy fails to bootstrap properly.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Logging_AccessLog_File_Path")]
        public System.String File_Path { get; set; }
        #endregion
        
        #region Parameter AwsCloudMap_ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS Cloud Map service to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_AwsCloudMap_ServiceName")]
        public System.String AwsCloudMap_ServiceName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you can apply to the virtual node to assist with categorization
        ///         and organization. Each tag consists of a key and an optional value, both of
        /// which you         define. Tag keys can have a maximum character length of 128 characters,
        /// and tag values can have            a maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AppMesh.Model.TagRef[] Tag { get; set; }
        #endregion
        
        #region Parameter VirtualNodeName
        /// <summary>
        /// <para>
        /// <para>The name to use for the virtual node.</para>
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
        public System.String VirtualNodeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualNode'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppMesh.Model.CreateVirtualNodeResponse).
        /// Specifying the name of a property of type Amazon.AppMesh.Model.CreateVirtualNodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualNode";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VirtualNodeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VirtualNodeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VirtualNodeName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VirtualNodeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSHVirtualNode (CreateVirtualNode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppMesh.Model.CreateVirtualNodeResponse, NewAMSHVirtualNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VirtualNodeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.MeshName = this.MeshName;
            #if MODULAR
            if (this.MeshName == null && ParameterWasBound(nameof(this.MeshName)))
            {
                WriteWarning("You are passing $null as a value for parameter MeshName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Spec_Backend != null)
            {
                context.Spec_Backend = new List<Amazon.AppMesh.Model.Backend>(this.Spec_Backend);
            }
            if (this.Spec_Listener != null)
            {
                context.Spec_Listener = new List<Amazon.AppMesh.Model.Listener>(this.Spec_Listener);
            }
            context.File_Path = this.File_Path;
            if (this.AwsCloudMap_Attribute != null)
            {
                context.AwsCloudMap_Attribute = new List<Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute>(this.AwsCloudMap_Attribute);
            }
            context.AwsCloudMap_NamespaceName = this.AwsCloudMap_NamespaceName;
            context.AwsCloudMap_ServiceName = this.AwsCloudMap_ServiceName;
            context.Dns_Hostname = this.Dns_Hostname;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AppMesh.Model.TagRef>(this.Tag);
            }
            context.VirtualNodeName = this.VirtualNodeName;
            #if MODULAR
            if (this.VirtualNodeName == null && ParameterWasBound(nameof(this.VirtualNodeName)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualNodeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppMesh.Model.CreateVirtualNodeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            
             // populate Spec
            var requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.VirtualNodeSpec();
            List<Amazon.AppMesh.Model.Backend> requestSpec_spec_Backend = null;
            if (cmdletContext.Spec_Backend != null)
            {
                requestSpec_spec_Backend = cmdletContext.Spec_Backend;
            }
            if (requestSpec_spec_Backend != null)
            {
                request.Spec.Backends = requestSpec_spec_Backend;
                requestSpecIsNull = false;
            }
            List<Amazon.AppMesh.Model.Listener> requestSpec_spec_Listener = null;
            if (cmdletContext.Spec_Listener != null)
            {
                requestSpec_spec_Listener = cmdletContext.Spec_Listener;
            }
            if (requestSpec_spec_Listener != null)
            {
                request.Spec.Listeners = requestSpec_spec_Listener;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.Logging requestSpec_spec_Logging = null;
            
             // populate Logging
            var requestSpec_spec_LoggingIsNull = true;
            requestSpec_spec_Logging = new Amazon.AppMesh.Model.Logging();
            Amazon.AppMesh.Model.AccessLog requestSpec_spec_Logging_spec_Logging_AccessLog = null;
            
             // populate AccessLog
            var requestSpec_spec_Logging_spec_Logging_AccessLogIsNull = true;
            requestSpec_spec_Logging_spec_Logging_AccessLog = new Amazon.AppMesh.Model.AccessLog();
            Amazon.AppMesh.Model.FileAccessLog requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = null;
            
             // populate File
            var requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull = true;
            requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = new Amazon.AppMesh.Model.FileAccessLog();
            System.String requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path = null;
            if (cmdletContext.File_Path != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path = cmdletContext.File_Path;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File.Path = requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path;
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull = false;
            }
             // determine if requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File should be set to null
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = null;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog.File = requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File;
                requestSpec_spec_Logging_spec_Logging_AccessLogIsNull = false;
            }
             // determine if requestSpec_spec_Logging_spec_Logging_AccessLog should be set to null
            if (requestSpec_spec_Logging_spec_Logging_AccessLogIsNull)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog = null;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog != null)
            {
                requestSpec_spec_Logging.AccessLog = requestSpec_spec_Logging_spec_Logging_AccessLog;
                requestSpec_spec_LoggingIsNull = false;
            }
             // determine if requestSpec_spec_Logging should be set to null
            if (requestSpec_spec_LoggingIsNull)
            {
                requestSpec_spec_Logging = null;
            }
            if (requestSpec_spec_Logging != null)
            {
                request.Spec.Logging = requestSpec_spec_Logging;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.ServiceDiscovery requestSpec_spec_ServiceDiscovery = null;
            
             // populate ServiceDiscovery
            var requestSpec_spec_ServiceDiscoveryIsNull = true;
            requestSpec_spec_ServiceDiscovery = new Amazon.AppMesh.Model.ServiceDiscovery();
            Amazon.AppMesh.Model.DnsServiceDiscovery requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = null;
            
             // populate Dns
            var requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull = true;
            requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = new Amazon.AppMesh.Model.DnsServiceDiscovery();
            System.String requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname = null;
            if (cmdletContext.Dns_Hostname != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname = cmdletContext.Dns_Hostname;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns.Hostname = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull = false;
            }
             // determine if requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns should be set to null
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = null;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns != null)
            {
                requestSpec_spec_ServiceDiscovery.Dns = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns;
                requestSpec_spec_ServiceDiscoveryIsNull = false;
            }
            Amazon.AppMesh.Model.AwsCloudMapServiceDiscovery requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap = null;
            
             // populate AwsCloudMap
            var requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = true;
            requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap = new Amazon.AppMesh.Model.AwsCloudMapServiceDiscovery();
            List<Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute> requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute = null;
            if (cmdletContext.AwsCloudMap_Attribute != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute = cmdletContext.AwsCloudMap_Attribute;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap.Attributes = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = false;
            }
            System.String requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName = null;
            if (cmdletContext.AwsCloudMap_NamespaceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName = cmdletContext.AwsCloudMap_NamespaceName;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap.NamespaceName = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = false;
            }
            System.String requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName = null;
            if (cmdletContext.AwsCloudMap_ServiceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName = cmdletContext.AwsCloudMap_ServiceName;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap.ServiceName = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = false;
            }
             // determine if requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap should be set to null
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap = null;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap != null)
            {
                requestSpec_spec_ServiceDiscovery.AwsCloudMap = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap;
                requestSpec_spec_ServiceDiscoveryIsNull = false;
            }
             // determine if requestSpec_spec_ServiceDiscovery should be set to null
            if (requestSpec_spec_ServiceDiscoveryIsNull)
            {
                requestSpec_spec_ServiceDiscovery = null;
            }
            if (requestSpec_spec_ServiceDiscovery != null)
            {
                request.Spec.ServiceDiscovery = requestSpec_spec_ServiceDiscovery;
                requestSpecIsNull = false;
            }
             // determine if request.Spec should be set to null
            if (requestSpecIsNull)
            {
                request.Spec = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VirtualNodeName != null)
            {
                request.VirtualNodeName = cmdletContext.VirtualNodeName;
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
        
        private Amazon.AppMesh.Model.CreateVirtualNodeResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.CreateVirtualNodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "CreateVirtualNode");
            try
            {
                #if DESKTOP
                return client.CreateVirtualNode(request);
                #elif CORECLR
                return client.CreateVirtualNodeAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String MeshName { get; set; }
            public List<Amazon.AppMesh.Model.Backend> Spec_Backend { get; set; }
            public List<Amazon.AppMesh.Model.Listener> Spec_Listener { get; set; }
            public System.String File_Path { get; set; }
            public List<Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute> AwsCloudMap_Attribute { get; set; }
            public System.String AwsCloudMap_NamespaceName { get; set; }
            public System.String AwsCloudMap_ServiceName { get; set; }
            public System.String Dns_Hostname { get; set; }
            public List<Amazon.AppMesh.Model.TagRef> Tag { get; set; }
            public System.String VirtualNodeName { get; set; }
            public System.Func<Amazon.AppMesh.Model.CreateVirtualNodeResponse, NewAMSHVirtualNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualNode;
        }
        
    }
}
