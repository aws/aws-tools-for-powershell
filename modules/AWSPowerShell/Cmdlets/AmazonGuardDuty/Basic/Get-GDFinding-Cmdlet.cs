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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Describes Amazon GuardDuty findings specified by finding IDs.
    /// </summary>
    [Cmdlet("Get", "GDFinding")]
    [OutputType("Amazon.GuardDuty.Model.Finding")]
    [AWSCmdlet("Calls the Amazon GuardDuty GetFindings API operation.", Operation = new[] {"GetFindings"})]
    [AWSCmdletOutput("Amazon.GuardDuty.Model.Finding",
        "This cmdlet returns a collection of Finding objects.",
        "The service call response (type Amazon.GuardDuty.Model.GetFindingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGDFindingCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// The ID of the detector that specifies the GuardDuty
        /// service whose findings you want to retrieve.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter FindingId
        /// <summary>
        /// <para>
        /// IDs of the findings that you want to retrieve.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("FindingIds")]
        public System.String[] FindingId { get; set; }
        #endregion
        
        #region Parameter SortCriterion
        /// <summary>
        /// <para>
        /// Represents the criteria used for sorting
        /// findings.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SortCriteria")]
        public Amazon.GuardDuty.Model.SortCriteria SortCriterion { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DetectorId = this.DetectorId;
            if (this.FindingId != null)
            {
                context.FindingIds = new List<System.String>(this.FindingId);
            }
            context.SortCriteria = this.SortCriterion;
            
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
            var request = new Amazon.GuardDuty.Model.GetFindingsRequest();
            
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.FindingIds != null)
            {
                request.FindingIds = cmdletContext.FindingIds;
            }
            if (cmdletContext.SortCriteria != null)
            {
                request.SortCriteria = cmdletContext.SortCriteria;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Findings;
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
        
        private Amazon.GuardDuty.Model.GetFindingsResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.GetFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "GetFindings");
            try
            {
                #if DESKTOP
                return client.GetFindings(request);
                #elif CORECLR
                return client.GetFindingsAsync(request).GetAwaiter().GetResult();
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
            public System.String DetectorId { get; set; }
            public List<System.String> FindingIds { get; set; }
            public Amazon.GuardDuty.Model.SortCriteria SortCriteria { get; set; }
        }
        
    }
}
