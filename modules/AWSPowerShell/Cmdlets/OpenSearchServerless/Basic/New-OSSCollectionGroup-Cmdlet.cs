/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Creates a collection group within OpenSearch Serverless. Collection groups let you
    /// manage OpenSearch Compute Units (OCUs) at a group level, with multiple collections
    /// sharing the group's capacity limits.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-collection-groups.html">Managing
    /// collection groups</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OSSCollectionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.CreateCollectionGroupDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless CreateCollectionGroup API operation.", Operation = new[] {"CreateCollectionGroup"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.CreateCollectionGroupDetail or Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.CreateCollectionGroupDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOSSCollectionGroupCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the collection group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter CapacityLimits_MaxIndexingCapacityInOCU
        /// <summary>
        /// <para>
        /// <para>The maximum indexing capacity for collections in the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? CapacityLimits_MaxIndexingCapacityInOCU { get; set; }
        #endregion
        
        #region Parameter CapacityLimits_MaxSearchCapacityInOCU
        /// <summary>
        /// <para>
        /// <para>The maximum search capacity for collections in the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? CapacityLimits_MaxSearchCapacityInOCU { get; set; }
        #endregion
        
        #region Parameter CapacityLimits_MinIndexingCapacityInOCU
        /// <summary>
        /// <para>
        /// <para>The minimum indexing capacity for collections in the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? CapacityLimits_MinIndexingCapacityInOCU { get; set; }
        #endregion
        
        #region Parameter CapacityLimits_MinSearchCapacityInOCU
        /// <summary>
        /// <para>
        /// <para>The minimum search capacity for collections in the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? CapacityLimits_MinSearchCapacityInOCU { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the collection group.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StandbyReplica
        /// <summary>
        /// <para>
        /// <para>Indicates whether standby replicas should be used for a collection group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StandbyReplicas")]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.StandbyReplicas")]
        public Amazon.OpenSearchServerless.StandbyReplicas StandbyReplica { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An arbitrary set of tags (key–value pairs) to associate with the OpenSearch Serverless
        /// collection group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.OpenSearchServerless.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CreateCollectionGroupDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CreateCollectionGroupDetail";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OSSCollectionGroup (CreateCollectionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse, NewOSSCollectionGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityLimits_MaxIndexingCapacityInOCU = this.CapacityLimits_MaxIndexingCapacityInOCU;
            context.CapacityLimits_MaxSearchCapacityInOCU = this.CapacityLimits_MaxSearchCapacityInOCU;
            context.CapacityLimits_MinIndexingCapacityInOCU = this.CapacityLimits_MinIndexingCapacityInOCU;
            context.CapacityLimits_MinSearchCapacityInOCU = this.CapacityLimits_MinSearchCapacityInOCU;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StandbyReplica = this.StandbyReplica;
            #if MODULAR
            if (this.StandbyReplica == null && ParameterWasBound(nameof(this.StandbyReplica)))
            {
                WriteWarning("You are passing $null as a value for parameter StandbyReplica which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.OpenSearchServerless.Model.Tag>(this.Tag);
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
            var request = new Amazon.OpenSearchServerless.Model.CreateCollectionGroupRequest();
            
            
             // populate CapacityLimits
            var requestCapacityLimitsIsNull = true;
            request.CapacityLimits = new Amazon.OpenSearchServerless.Model.CollectionGroupCapacityLimits();
            System.Single? requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU = null;
            if (cmdletContext.CapacityLimits_MaxIndexingCapacityInOCU != null)
            {
                requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU = cmdletContext.CapacityLimits_MaxIndexingCapacityInOCU.Value;
            }
            if (requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU != null)
            {
                request.CapacityLimits.MaxIndexingCapacityInOCU = requestCapacityLimits_capacityLimits_MaxIndexingCapacityInOCU.Value;
                requestCapacityLimitsIsNull = false;
            }
            System.Single? requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU = null;
            if (cmdletContext.CapacityLimits_MaxSearchCapacityInOCU != null)
            {
                requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU = cmdletContext.CapacityLimits_MaxSearchCapacityInOCU.Value;
            }
            if (requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU != null)
            {
                request.CapacityLimits.MaxSearchCapacityInOCU = requestCapacityLimits_capacityLimits_MaxSearchCapacityInOCU.Value;
                requestCapacityLimitsIsNull = false;
            }
            System.Single? requestCapacityLimits_capacityLimits_MinIndexingCapacityInOCU = null;
            if (cmdletContext.CapacityLimits_MinIndexingCapacityInOCU != null)
            {
                requestCapacityLimits_capacityLimits_MinIndexingCapacityInOCU = cmdletContext.CapacityLimits_MinIndexingCapacityInOCU.Value;
            }
            if (requestCapacityLimits_capacityLimits_MinIndexingCapacityInOCU != null)
            {
                request.CapacityLimits.MinIndexingCapacityInOCU = requestCapacityLimits_capacityLimits_MinIndexingCapacityInOCU.Value;
                requestCapacityLimitsIsNull = false;
            }
            System.Single? requestCapacityLimits_capacityLimits_MinSearchCapacityInOCU = null;
            if (cmdletContext.CapacityLimits_MinSearchCapacityInOCU != null)
            {
                requestCapacityLimits_capacityLimits_MinSearchCapacityInOCU = cmdletContext.CapacityLimits_MinSearchCapacityInOCU.Value;
            }
            if (requestCapacityLimits_capacityLimits_MinSearchCapacityInOCU != null)
            {
                request.CapacityLimits.MinSearchCapacityInOCU = requestCapacityLimits_capacityLimits_MinSearchCapacityInOCU.Value;
                requestCapacityLimitsIsNull = false;
            }
             // determine if request.CapacityLimits should be set to null
            if (requestCapacityLimitsIsNull)
            {
                request.CapacityLimits = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.StandbyReplica != null)
            {
                request.StandbyReplicas = cmdletContext.StandbyReplica;
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
        
        private Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.CreateCollectionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "CreateCollectionGroup");
            try
            {
                #if DESKTOP
                return client.CreateCollectionGroup(request);
                #elif CORECLR
                return client.CreateCollectionGroupAsync(request).GetAwaiter().GetResult();
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
            public System.Single? CapacityLimits_MaxIndexingCapacityInOCU { get; set; }
            public System.Single? CapacityLimits_MaxSearchCapacityInOCU { get; set; }
            public System.Single? CapacityLimits_MinIndexingCapacityInOCU { get; set; }
            public System.Single? CapacityLimits_MinSearchCapacityInOCU { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Amazon.OpenSearchServerless.StandbyReplicas StandbyReplica { get; set; }
            public List<Amazon.OpenSearchServerless.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.CreateCollectionGroupResponse, NewOSSCollectionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CreateCollectionGroupDetail;
        }
        
    }
}
