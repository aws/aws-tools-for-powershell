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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Updates the recommendation status and recommended action status for the specified
    /// recommendation.
    /// </summary>
    [Cmdlet("Edit", "RDSDBRecommendation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBRecommendation")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBRecommendation API operation.", Operation = new[] {"ModifyDBRecommendation"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBRecommendationResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBRecommendation or Amazon.RDS.Model.ModifyDBRecommendationResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBRecommendation object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBRecommendationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBRecommendationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The language of the modified recommendation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter RecommendationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the recommendation to update.</para>
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
        public System.String RecommendationId { get; set; }
        #endregion
        
        #region Parameter RecommendedActionUpdate
        /// <summary>
        /// <para>
        /// <para>The list of recommended action status to update. You can update multiple recommended
        /// actions at one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendedActionUpdates")]
        public Amazon.RDS.Model.RecommendedActionUpdate[] RecommendedActionUpdate { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The recommendation status to update.</para><para>Valid values:</para><ul><li><para>active</para></li><li><para>dismissed</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBRecommendation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBRecommendationResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBRecommendation";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RecommendationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBRecommendation (ModifyDBRecommendation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBRecommendationResponse, EditRDSDBRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Locale = this.Locale;
            context.RecommendationId = this.RecommendationId;
            #if MODULAR
            if (this.RecommendationId == null && ParameterWasBound(nameof(this.RecommendationId)))
            {
                WriteWarning("You are passing $null as a value for parameter RecommendationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RecommendedActionUpdate != null)
            {
                context.RecommendedActionUpdate = new List<Amazon.RDS.Model.RecommendedActionUpdate>(this.RecommendedActionUpdate);
            }
            context.Status = this.Status;
            
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
            var request = new Amazon.RDS.Model.ModifyDBRecommendationRequest();
            
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.RecommendationId != null)
            {
                request.RecommendationId = cmdletContext.RecommendationId;
            }
            if (cmdletContext.RecommendedActionUpdate != null)
            {
                request.RecommendedActionUpdates = cmdletContext.RecommendedActionUpdate;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.RDS.Model.ModifyDBRecommendationResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBRecommendation");
            try
            {
                #if DESKTOP
                return client.ModifyDBRecommendation(request);
                #elif CORECLR
                return client.ModifyDBRecommendationAsync(request).GetAwaiter().GetResult();
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
            public System.String Locale { get; set; }
            public System.String RecommendationId { get; set; }
            public List<Amazon.RDS.Model.RecommendedActionUpdate> RecommendedActionUpdate { get; set; }
            public System.String Status { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBRecommendationResponse, EditRDSDBRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBRecommendation;
        }
        
    }
}
