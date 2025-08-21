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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Annotate datapoints over time for a specific data quality statistic. The API requires
    /// both profileID and statisticID as part of the InclusionAnnotation input. The API only
    /// works for a single statisticId across multiple profiles.
    /// </summary>
    [Cmdlet("Set", "GLUEBatchDataQualityStatisticAnnotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.AnnotationError")]
    [AWSCmdlet("Calls the AWS Glue BatchPutDataQualityStatisticAnnotation API operation.", Operation = new[] {"BatchPutDataQualityStatisticAnnotation"}, SelectReturnType = typeof(Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.AnnotationError or Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse",
        "This cmdlet returns a collection of Amazon.Glue.Model.AnnotationError objects.",
        "The service call response (type Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetGLUEBatchDataQualityStatisticAnnotationCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InclusionAnnotation
        /// <summary>
        /// <para>
        /// <para>A list of <c>DatapointInclusionAnnotation</c>'s. The InclusionAnnotations must contain
        /// a profileId and statisticId. If there are multiple InclusionAnnotations, the list
        /// must refer to a single statisticId across multiple profileIds.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InclusionAnnotations")]
        public Amazon.Glue.Model.DatapointInclusionAnnotation[] InclusionAnnotation { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Client Token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedInclusionAnnotations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedInclusionAnnotations";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InclusionAnnotation), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-GLUEBatchDataQualityStatisticAnnotation (BatchPutDataQualityStatisticAnnotation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse, SetGLUEBatchDataQualityStatisticAnnotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.InclusionAnnotation != null)
            {
                context.InclusionAnnotation = new List<Amazon.Glue.Model.DatapointInclusionAnnotation>(this.InclusionAnnotation);
            }
            #if MODULAR
            if (this.InclusionAnnotation == null && ParameterWasBound(nameof(this.InclusionAnnotation)))
            {
                WriteWarning("You are passing $null as a value for parameter InclusionAnnotation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InclusionAnnotation != null)
            {
                request.InclusionAnnotations = cmdletContext.InclusionAnnotation;
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
        
        private Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "BatchPutDataQualityStatisticAnnotation");
            try
            {
                #if DESKTOP
                return client.BatchPutDataQualityStatisticAnnotation(request);
                #elif CORECLR
                return client.BatchPutDataQualityStatisticAnnotationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Glue.Model.DatapointInclusionAnnotation> InclusionAnnotation { get; set; }
            public System.Func<Amazon.Glue.Model.BatchPutDataQualityStatisticAnnotationResponse, SetGLUEBatchDataQualityStatisticAnnotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedInclusionAnnotations;
        }
        
    }
}
