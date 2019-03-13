/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// must specify the         DNS service discovery hostname for your task group.
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
    [AWSCmdlet("Calls the AWS App Mesh CreateVirtualNode API operation.", Operation = new[] {"CreateVirtualNode"})]
    [AWSCmdletOutput("Amazon.AppMesh.Model.VirtualNodeData",
        "This cmdlet returns a VirtualNodeData object.",
        "The service call response (type Amazon.AppMesh.Model.CreateVirtualNodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAMSHVirtualNodeCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        #region Parameter Spec_Backend
        /// <summary>
        /// <para>
        /// <para>The backends that the virtual node is expected to send outbound traffic to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Dns_Hostname
        /// <summary>
        /// <para>
        /// <para>Specifies the DNS service discovery hostname for the virtual node. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Spec_ServiceDiscovery_Dns_Hostname")]
        public System.String Dns_Hostname { get; set; }
        #endregion
        
        #region Parameter Spec_Listener
        /// <summary>
        /// <para>
        /// <para>The listeners that the virtual node is expected to receive inbound traffic from. Currently
        /// only one listener is supported per virtual node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Spec_Listeners")]
        public Amazon.AppMesh.Model.Listener[] Spec_Listener { get; set; }
        #endregion
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh to create the virtual node in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter File_Path
        /// <summary>
        /// <para>
        /// <para>The file path to write access logs to. You can use <code>/dev/stdout</code> to send
        ///         access logs to standard out and configure your Envoy container to use a log
        /// driver, such as            <code>awslogs</code>, to export the access logs to a log
        /// storage service such as Amazon CloudWatch         Logs. You can also specify a path
        /// in the Envoy container's file system to write the files         to disk.</para><note><para>The Envoy process must have write permissions to the path that you specify here. 
        ///           Otherwise, Envoy fails to bootstrap properly.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Spec_Logging_AccessLog_File_Path")]
        public System.String File_Path { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you can apply to the virtual node to assist with categorization
        /// and organization.         Each tag consists of a key and an optional value, both of
        /// which you define.         Tag keys can have a maximum character length of 128 characters,
        /// and tag values can have            a maximum length of 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.AppMesh.Model.TagRef[] Tag { get; set; }
        #endregion
        
        #region Parameter VirtualNodeName
        /// <summary>
        /// <para>
        /// <para>The name to use for the virtual node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String VirtualNodeName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VirtualNodeName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AMSHVirtualNode (CreateVirtualNode)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            context.MeshName = this.MeshName;
            if (this.Spec_Backend != null)
            {
                context.Spec_Backends = new List<Amazon.AppMesh.Model.Backend>(this.Spec_Backend);
            }
            if (this.Spec_Listener != null)
            {
                context.Spec_Listeners = new List<Amazon.AppMesh.Model.Listener>(this.Spec_Listener);
            }
            context.Spec_Logging_AccessLog_File_Path = this.File_Path;
            context.Spec_ServiceDiscovery_Dns_Hostname = this.Dns_Hostname;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.AppMesh.Model.TagRef>(this.Tag);
            }
            context.VirtualNodeName = this.VirtualNodeName;
            
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
            bool requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.VirtualNodeSpec();
            List<Amazon.AppMesh.Model.Backend> requestSpec_spec_Backend = null;
            if (cmdletContext.Spec_Backends != null)
            {
                requestSpec_spec_Backend = cmdletContext.Spec_Backends;
            }
            if (requestSpec_spec_Backend != null)
            {
                request.Spec.Backends = requestSpec_spec_Backend;
                requestSpecIsNull = false;
            }
            List<Amazon.AppMesh.Model.Listener> requestSpec_spec_Listener = null;
            if (cmdletContext.Spec_Listeners != null)
            {
                requestSpec_spec_Listener = cmdletContext.Spec_Listeners;
            }
            if (requestSpec_spec_Listener != null)
            {
                request.Spec.Listeners = requestSpec_spec_Listener;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.Logging requestSpec_spec_Logging = null;
            
             // populate Logging
            bool requestSpec_spec_LoggingIsNull = true;
            requestSpec_spec_Logging = new Amazon.AppMesh.Model.Logging();
            Amazon.AppMesh.Model.AccessLog requestSpec_spec_Logging_spec_Logging_AccessLog = null;
            
             // populate AccessLog
            bool requestSpec_spec_Logging_spec_Logging_AccessLogIsNull = true;
            requestSpec_spec_Logging_spec_Logging_AccessLog = new Amazon.AppMesh.Model.AccessLog();
            Amazon.AppMesh.Model.FileAccessLog requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = null;
            
             // populate File
            bool requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull = true;
            requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = new Amazon.AppMesh.Model.FileAccessLog();
            System.String requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path = null;
            if (cmdletContext.Spec_Logging_AccessLog_File_Path != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path = cmdletContext.Spec_Logging_AccessLog_File_Path;
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
            bool requestSpec_spec_ServiceDiscoveryIsNull = true;
            requestSpec_spec_ServiceDiscovery = new Amazon.AppMesh.Model.ServiceDiscovery();
            Amazon.AppMesh.Model.DnsServiceDiscovery requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = null;
            
             // populate Dns
            bool requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull = true;
            requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = new Amazon.AppMesh.Model.DnsServiceDiscovery();
            System.String requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname = null;
            if (cmdletContext.Spec_ServiceDiscovery_Dns_Hostname != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname = cmdletContext.Spec_ServiceDiscovery_Dns_Hostname;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.VirtualNodeName != null)
            {
                request.VirtualNodeName = cmdletContext.VirtualNodeName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VirtualNode;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            public List<Amazon.AppMesh.Model.Backend> Spec_Backends { get; set; }
            public List<Amazon.AppMesh.Model.Listener> Spec_Listeners { get; set; }
            public System.String Spec_Logging_AccessLog_File_Path { get; set; }
            public System.String Spec_ServiceDiscovery_Dns_Hostname { get; set; }
            public List<Amazon.AppMesh.Model.TagRef> Tags { get; set; }
            public System.String VirtualNodeName { get; set; }
        }
        
    }
}
