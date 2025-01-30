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
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Retrieves a list of the IDs of findings, plus their last modified times, that have
    /// been identified for a specified incident. A finding represents a recent application
    /// environment change made by an CloudFormation stack creation or update or an CodeDeploy
    /// deployment that can be investigated as a potential cause of the incident.
    /// </summary>
    [Cmdlet("Get", "SSMIIncidentFindingList")]
    [OutputType("Amazon.SSMIncidents.Model.FindingSummary")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager ListIncidentFindings API operation.", Operation = new[] {"ListIncidentFindings"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.ListIncidentFindingsResponse))]
    [AWSCmdletOutput("Amazon.SSMIncidents.Model.FindingSummary or Amazon.SSMIncidents.Model.ListIncidentFindingsResponse",
        "This cmdlet returns a collection of Amazon.SSMIncidents.Model.FindingSummary objects.",
        "The service call response (type Amazon.SSMIncidents.Model.ListIncidentFindingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMIIncidentFindingListCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncidentRecordArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the incident for which you want to view associated
        /// findings.</para>
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
        public System.String IncidentRecordArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of findings to retrieve per call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token for the next set of items to return. (You received this token
        /// from a previous call.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Findings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.ListIncidentFindingsResponse).
        /// Specifying the name of a property of type Amazon.SSMIncidents.Model.ListIncidentFindingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Findings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IncidentRecordArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IncidentRecordArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IncidentRecordArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.ListIncidentFindingsResponse, GetSSMIIncidentFindingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IncidentRecordArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IncidentRecordArn = this.IncidentRecordArn;
            #if MODULAR
            if (this.IncidentRecordArn == null && ParameterWasBound(nameof(this.IncidentRecordArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IncidentRecordArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.SSMIncidents.Model.ListIncidentFindingsRequest();
            
            if (cmdletContext.IncidentRecordArn != null)
            {
                request.IncidentRecordArn = cmdletContext.IncidentRecordArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.SSMIncidents.Model.ListIncidentFindingsResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.ListIncidentFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "ListIncidentFindings");
            try
            {
                #if DESKTOP
                return client.ListIncidentFindings(request);
                #elif CORECLR
                return client.ListIncidentFindingsAsync(request).GetAwaiter().GetResult();
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
            public System.String IncidentRecordArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.ListIncidentFindingsResponse, GetSSMIIncidentFindingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Findings;
        }
        
    }
}
