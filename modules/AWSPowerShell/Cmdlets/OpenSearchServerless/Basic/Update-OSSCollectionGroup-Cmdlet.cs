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
    /// Updates the description and capacity limits of a collection group.
    /// </summary>
    [Cmdlet("Update", "OSSCollectionGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.UpdateCollectionGroupDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless UpdateCollectionGroup API operation.", Operation = new[] {"UpdateCollectionGroup"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.UpdateCollectionGroupDetail or Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.UpdateCollectionGroupDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOSSCollectionGroupCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the collection group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the collection group to update.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UpdateCollectionGroupDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UpdateCollectionGroupDetail";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSSCollectionGroup (UpdateCollectionGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse, UpdateOSSCollectionGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CapacityLimits_MaxIndexingCapacityInOCU = this.CapacityLimits_MaxIndexingCapacityInOCU;
            context.CapacityLimits_MaxSearchCapacityInOCU = this.CapacityLimits_MaxSearchCapacityInOCU;
            context.CapacityLimits_MinIndexingCapacityInOCU = this.CapacityLimits_MinIndexingCapacityInOCU;
            context.CapacityLimits_MinSearchCapacityInOCU = this.CapacityLimits_MinSearchCapacityInOCU;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchServerless.Model.UpdateCollectionGroupRequest();
            
            
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
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.UpdateCollectionGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "UpdateCollectionGroup");
            try
            {
                #if DESKTOP
                return client.UpdateCollectionGroup(request);
                #elif CORECLR
                return client.UpdateCollectionGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.UpdateCollectionGroupResponse, UpdateOSSCollectionGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UpdateCollectionGroupDetail;
        }
        
    }
}
