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
using Amazon.NeptuneGraph;
using Amazon.NeptuneGraph.Model;

namespace Amazon.PowerShell.Cmdlets.NEPTG
{
    /// <summary>
    /// Creates a new Neptune Analytics graph.
    /// </summary>
    [Cmdlet("New", "NEPTGGraph", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NeptuneGraph.Model.CreateGraphResponse")]
    [AWSCmdlet("Calls the Amazon Neptune Graph CreateGraph API operation.", Operation = new[] {"CreateGraph"}, SelectReturnType = typeof(Amazon.NeptuneGraph.Model.CreateGraphResponse))]
    [AWSCmdletOutput("Amazon.NeptuneGraph.Model.CreateGraphResponse",
        "This cmdlet returns an Amazon.NeptuneGraph.Model.CreateGraphResponse object containing multiple properties."
    )]
    public partial class NewNEPTGGraphCmdlet : AmazonNeptuneGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Indicates whether or not to enable deletion protection on the graph. The graph can’t
        /// be deleted when deletion protection is enabled. (<c>true</c> or <c>false</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter VectorSearchConfiguration_Dimension
        /// <summary>
        /// <para>
        /// <para>The number of dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VectorSearchConfiguration_Dimension { get; set; }
        #endregion
        
        #region Parameter GraphName
        /// <summary>
        /// <para>
        /// <para>A name for the new Neptune Analytics graph to be created.</para><para>The name must contain from 1 to 63 letters, numbers, or hyphens, and its first character
        /// must be a letter. It cannot end with a hyphen or contain two consecutive hyphens.
        /// </para>
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
        public System.String GraphName { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>Specifies a KMS key to use to encrypt data in the new graph.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter ProvisionedMemory
        /// <summary>
        /// <para>
        /// <para>The provisioned memory-optimized Neptune Capacity Units (m-NCUs) to use for the graph.
        /// Min = 128</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ProvisionedMemory { get; set; }
        #endregion
        
        #region Parameter PublicConnectivity
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not the graph can be reachable over the internet. All access
        /// to graphs is IAM authenticated. (<c>true</c> to enable, or <c>false</c> to disable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicConnectivity { get; set; }
        #endregion
        
        #region Parameter ReplicaCount
        /// <summary>
        /// <para>
        /// <para>The number of replicas in other AZs. Min =0, Max = 2, Default = 1.</para><important><para> Additional charges equivalent to the m-NCUs selected for the graph apply for each
        /// replica. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ReplicaCount { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Adds metadata tags to the new graph. These tags can also be used with cost allocation
        /// reporting, or used in a Condition statement in an IAM policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NeptuneGraph.Model.CreateGraphResponse).
        /// Specifying the name of a property of type Amazon.NeptuneGraph.Model.CreateGraphResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GraphName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NEPTGGraph (CreateGraph)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NeptuneGraph.Model.CreateGraphResponse, NewNEPTGGraphCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionProtection = this.DeletionProtection;
            context.GraphName = this.GraphName;
            #if MODULAR
            if (this.GraphName == null && ParameterWasBound(nameof(this.GraphName)))
            {
                WriteWarning("You are passing $null as a value for parameter GraphName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.ProvisionedMemory = this.ProvisionedMemory;
            #if MODULAR
            if (this.ProvisionedMemory == null && ParameterWasBound(nameof(this.ProvisionedMemory)))
            {
                WriteWarning("You are passing $null as a value for parameter ProvisionedMemory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicConnectivity = this.PublicConnectivity;
            context.ReplicaCount = this.ReplicaCount;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.VectorSearchConfiguration_Dimension = this.VectorSearchConfiguration_Dimension;
            
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
            var request = new Amazon.NeptuneGraph.Model.CreateGraphRequest();
            
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.GraphName != null)
            {
                request.GraphName = cmdletContext.GraphName;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.ProvisionedMemory != null)
            {
                request.ProvisionedMemory = cmdletContext.ProvisionedMemory.Value;
            }
            if (cmdletContext.PublicConnectivity != null)
            {
                request.PublicConnectivity = cmdletContext.PublicConnectivity.Value;
            }
            if (cmdletContext.ReplicaCount != null)
            {
                request.ReplicaCount = cmdletContext.ReplicaCount.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VectorSearchConfiguration
            var requestVectorSearchConfigurationIsNull = true;
            request.VectorSearchConfiguration = new Amazon.NeptuneGraph.Model.VectorSearchConfiguration();
            System.Int32? requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension = null;
            if (cmdletContext.VectorSearchConfiguration_Dimension != null)
            {
                requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension = cmdletContext.VectorSearchConfiguration_Dimension.Value;
            }
            if (requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension != null)
            {
                request.VectorSearchConfiguration.Dimension = requestVectorSearchConfiguration_vectorSearchConfiguration_Dimension.Value;
                requestVectorSearchConfigurationIsNull = false;
            }
             // determine if request.VectorSearchConfiguration should be set to null
            if (requestVectorSearchConfigurationIsNull)
            {
                request.VectorSearchConfiguration = null;
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
        
        private Amazon.NeptuneGraph.Model.CreateGraphResponse CallAWSServiceOperation(IAmazonNeptuneGraph client, Amazon.NeptuneGraph.Model.CreateGraphRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune Graph", "CreateGraph");
            try
            {
                #if DESKTOP
                return client.CreateGraph(request);
                #elif CORECLR
                return client.CreateGraphAsync(request).GetAwaiter().GetResult();
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
            public System.String GraphName { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.Int32? ProvisionedMemory { get; set; }
            public System.Boolean? PublicConnectivity { get; set; }
            public System.Int32? ReplicaCount { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? VectorSearchConfiguration_Dimension { get; set; }
            public System.Func<Amazon.NeptuneGraph.Model.CreateGraphResponse, NewNEPTGGraphCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
