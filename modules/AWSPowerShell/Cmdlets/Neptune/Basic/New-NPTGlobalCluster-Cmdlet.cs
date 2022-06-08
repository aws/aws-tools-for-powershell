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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Creates a Neptune global database spread across multiple Amazon Regions. The global
    /// database contains a single primary cluster with read-write capability, and read-only
    /// secondary clusters that receive data from the primary cluster through high-speed replication
    /// performed by the Neptune storage subsystem.
    /// 
    ///  
    /// <para>
    /// You can create a global database that is initially empty, and then add a primary cluster
    /// and secondary clusters to it, or you can specify an existing Neptune cluster during
    /// the create operation to become the primary cluster of the global database.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NPTGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon Neptune CreateGlobalCluster API operation.", Operation = new[] {"CreateGlobalCluster"}, SelectReturnType = typeof(Amazon.Neptune.Model.CreateGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.GlobalCluster or Amazon.Neptune.Model.CreateGlobalClusterResponse",
        "This cmdlet returns an Amazon.Neptune.Model.GlobalCluster object.",
        "The service call response (type Amazon.Neptune.Model.CreateGlobalClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewNPTGlobalClusterCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>The deletion protection setting for the new global database. The global database can't
        /// be deleted when deletion protection is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the database engine to be used in the global database.</para><para>Valid values: <code>neptune</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The Neptune engine version to be used by the global database.</para><para>Valid values: <code>1.2.0.0</code> or above.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier of the new global database cluster.</para>
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
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceDBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>(<i>Optional</i>) The Amazon Resource Name (ARN) of an existing Neptune DB cluster
        /// to use as the primary cluster of the new global database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceDBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter StorageEncrypted
        /// <summary>
        /// <para>
        /// <para>The storage encryption setting for the new global database cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StorageEncrypted { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.CreateGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.CreateGlobalClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NPTGlobalCluster (CreateGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.CreateGlobalClusterResponse, NewNPTGlobalClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeletionProtection = this.DeletionProtection;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            #if MODULAR
            if (this.GlobalClusterIdentifier == null && ParameterWasBound(nameof(this.GlobalClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceDBClusterIdentifier = this.SourceDBClusterIdentifier;
            context.StorageEncrypted = this.StorageEncrypted;
            
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
            var request = new Amazon.Neptune.Model.CreateGlobalClusterRequest();
            
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
            }
            if (cmdletContext.SourceDBClusterIdentifier != null)
            {
                request.SourceDBClusterIdentifier = cmdletContext.SourceDBClusterIdentifier;
            }
            if (cmdletContext.StorageEncrypted != null)
            {
                request.StorageEncrypted = cmdletContext.StorageEncrypted.Value;
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
        
        private Amazon.Neptune.Model.CreateGlobalClusterResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.CreateGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "CreateGlobalCluster");
            try
            {
                #if DESKTOP
                return client.CreateGlobalCluster(request);
                #elif CORECLR
                return client.CreateGlobalClusterAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.String SourceDBClusterIdentifier { get; set; }
            public System.Boolean? StorageEncrypted { get; set; }
            public System.Func<Amazon.Neptune.Model.CreateGlobalClusterResponse, NewNPTGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}
