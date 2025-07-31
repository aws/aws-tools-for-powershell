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
using Amazon.SimpleEmailV2;
using Amazon.SimpleEmailV2.Model;

namespace Amazon.PowerShell.Cmdlets.SES2
{
    /// <summary>
    /// Retrieve information about a specific reputation entity, including its reputation
    /// management policy, customer-managed status, Amazon Web Services Amazon SES-managed
    /// status, and aggregate sending status.
    /// 
    ///  
    /// <para><i>Reputation entities</i> represent resources in your Amazon SES account that have
    /// reputation tracking and management capabilities. The reputation impact reflects the
    /// highest impact reputation finding for the entity. Reputation findings can be retrieved
    /// using the <c>ListRecommendations</c> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SES2ReputationEntity")]
    [OutputType("Amazon.SimpleEmailV2.Model.ReputationEntity")]
    [AWSCmdlet("Calls the Amazon Simple Email Service V2 (SES V2) GetReputationEntity API operation.", Operation = new[] {"GetReputationEntity"}, SelectReturnType = typeof(Amazon.SimpleEmailV2.Model.GetReputationEntityResponse))]
    [AWSCmdletOutput("Amazon.SimpleEmailV2.Model.ReputationEntity or Amazon.SimpleEmailV2.Model.GetReputationEntityResponse",
        "This cmdlet returns an Amazon.SimpleEmailV2.Model.ReputationEntity object.",
        "The service call response (type Amazon.SimpleEmailV2.Model.GetReputationEntityResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSES2ReputationEntityCmdlet : AmazonSimpleEmailServiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ReputationEntityReference
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the reputation entity. For resource-type entities, this
        /// is the Amazon Resource Name (ARN) of the resource.</para>
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
        public System.String ReputationEntityReference { get; set; }
        #endregion
        
        #region Parameter ReputationEntityType
        /// <summary>
        /// <para>
        /// <para>The type of reputation entity. Currently, only <c>RESOURCE</c> type entities are supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleEmailV2.ReputationEntityType")]
        public Amazon.SimpleEmailV2.ReputationEntityType ReputationEntityType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReputationEntity'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmailV2.Model.GetReputationEntityResponse).
        /// Specifying the name of a property of type Amazon.SimpleEmailV2.Model.GetReputationEntityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReputationEntity";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReputationEntityReference parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReputationEntityReference' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReputationEntityReference' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmailV2.Model.GetReputationEntityResponse, GetSES2ReputationEntityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReputationEntityReference;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ReputationEntityReference = this.ReputationEntityReference;
            #if MODULAR
            if (this.ReputationEntityReference == null && ParameterWasBound(nameof(this.ReputationEntityReference)))
            {
                WriteWarning("You are passing $null as a value for parameter ReputationEntityReference which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReputationEntityType = this.ReputationEntityType;
            #if MODULAR
            if (this.ReputationEntityType == null && ParameterWasBound(nameof(this.ReputationEntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter ReputationEntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleEmailV2.Model.GetReputationEntityRequest();
            
            if (cmdletContext.ReputationEntityReference != null)
            {
                request.ReputationEntityReference = cmdletContext.ReputationEntityReference;
            }
            if (cmdletContext.ReputationEntityType != null)
            {
                request.ReputationEntityType = cmdletContext.ReputationEntityType;
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
        
        private Amazon.SimpleEmailV2.Model.GetReputationEntityResponse CallAWSServiceOperation(IAmazonSimpleEmailServiceV2 client, Amazon.SimpleEmailV2.Model.GetReputationEntityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service V2 (SES V2)", "GetReputationEntity");
            try
            {
                #if DESKTOP
                return client.GetReputationEntity(request);
                #elif CORECLR
                return client.GetReputationEntityAsync(request).GetAwaiter().GetResult();
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
            public System.String ReputationEntityReference { get; set; }
            public Amazon.SimpleEmailV2.ReputationEntityType ReputationEntityType { get; set; }
            public System.Func<Amazon.SimpleEmailV2.Model.GetReputationEntityResponse, GetSES2ReputationEntityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReputationEntity;
        }
        
    }
}
