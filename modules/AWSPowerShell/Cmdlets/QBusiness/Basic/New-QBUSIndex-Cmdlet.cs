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
using System.Threading;
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Creates an Amazon Q Business index.
    /// 
    ///  
    /// <para>
    /// To determine if index creation has completed, check the <c>Status</c> field returned
    /// from a call to <c>DescribeIndex</c>. The <c>Status</c> field is set to <c>ACTIVE</c>
    /// when the index is ready to use.
    /// </para><para>
    /// Once the index is active, you can index your documents using the <a href="https://docs.aws.amazon.com/amazonq/latest/api-reference/API_BatchPutDocument.html"><c>BatchPutDocument</c></a> API or the <a href="https://docs.aws.amazon.com/amazonq/latest/api-reference/API_CreateDataSource.html"><c>CreateDataSource</c></a> API.
    /// </para>
    /// </summary>
    [Cmdlet("New", "QBUSIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QBusiness.Model.CreateIndexResponse")]
    [AWSCmdlet("Calls the Amazon QBusiness CreateIndex API operation.", Operation = new[] {"CreateIndex"}, SelectReturnType = typeof(Amazon.QBusiness.Model.CreateIndexResponse))]
    [AWSCmdletOutput("Amazon.QBusiness.Model.CreateIndexResponse",
        "This cmdlet returns an Amazon.QBusiness.Model.CreateIndexResponse object containing multiple properties."
    )]
    public partial class NewQBUSIndexCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q Business application using the index.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the Amazon Q Business index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A name for the Amazon Q Business index.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that identify or categorize the index. You can also use
        /// tags to help control access to the index. Tag keys and values can consist of Unicode
        /// letters, digits, white space, and any of the following symbols: _ . : / = + - @.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The index type that's suitable for your needs. For more information on what's included
        /// in each type of index, see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/tiers.html#index-tiers">Amazon
        /// Q Business tiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.IndexType")]
        public Amazon.QBusiness.IndexType Type { get; set; }
        #endregion
        
        #region Parameter CapacityConfiguration_Unit
        /// <summary>
        /// <para>
        /// <para>The number of storage units configured for an Amazon Q Business index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityConfiguration_Units")]
        public System.Int32? CapacityConfiguration_Unit { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that you provide to identify the request to create an index. Multiple calls
        /// to the <c>CreateIndex</c> API with the same client token will create only one index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.CreateIndexResponse).
        /// Specifying the name of a property of type Amazon.QBusiness.Model.CreateIndexResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QBUSIndex (CreateIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.CreateIndexResponse, NewQBUSIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CapacityConfiguration_Unit = this.CapacityConfiguration_Unit;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QBusiness.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            
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
            var request = new Amazon.QBusiness.Model.CreateIndexRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate CapacityConfiguration
            var requestCapacityConfigurationIsNull = true;
            request.CapacityConfiguration = new Amazon.QBusiness.Model.IndexCapacityConfiguration();
            System.Int32? requestCapacityConfiguration_capacityConfiguration_Unit = null;
            if (cmdletContext.CapacityConfiguration_Unit != null)
            {
                requestCapacityConfiguration_capacityConfiguration_Unit = cmdletContext.CapacityConfiguration_Unit.Value;
            }
            if (requestCapacityConfiguration_capacityConfiguration_Unit != null)
            {
                request.CapacityConfiguration.Units = requestCapacityConfiguration_capacityConfiguration_Unit.Value;
                requestCapacityConfigurationIsNull = false;
            }
             // determine if request.CapacityConfiguration should be set to null
            if (requestCapacityConfigurationIsNull)
            {
                request.CapacityConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.QBusiness.Model.CreateIndexResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.CreateIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "CreateIndex");
            try
            {
                return client.CreateIndexAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.Int32? CapacityConfiguration_Unit { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public List<Amazon.QBusiness.Model.Tag> Tag { get; set; }
            public Amazon.QBusiness.IndexType Type { get; set; }
            public System.Func<Amazon.QBusiness.Model.CreateIndexResponse, NewQBUSIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
