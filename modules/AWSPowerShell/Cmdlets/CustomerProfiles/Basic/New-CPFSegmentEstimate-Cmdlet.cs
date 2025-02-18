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
using Amazon.CustomerProfiles;
using Amazon.CustomerProfiles.Model;

namespace Amazon.PowerShell.Cmdlets.CPF
{
    /// <summary>
    /// Creates a segment estimate query.
    /// </summary>
    [Cmdlet("New", "CPFSegmentEstimate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse")]
    [AWSCmdlet("Calls the Amazon Connect Customer Profiles CreateSegmentEstimate API operation.", Operation = new[] {"CreateSegmentEstimate"}, SelectReturnType = typeof(Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse))]
    [AWSCmdletOutput("Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse",
        "This cmdlet returns an Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse object containing multiple properties."
    )]
    public partial class NewCPFSegmentEstimateCmdlet : AmazonCustomerProfilesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The unique name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter SegmentQuery_Group
        /// <summary>
        /// <para>
        /// <para>Holds the list of groups within the segment definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SegmentQuery_Groups")]
        public Amazon.CustomerProfiles.Model.Group[] SegmentQuery_Group { get; set; }
        #endregion
        
        #region Parameter SegmentQuery_Include
        /// <summary>
        /// <para>
        /// <para>Define whether to include or exclude the profiles that fit the segment criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CustomerProfiles.IncludeOptions")]
        public Amazon.CustomerProfiles.IncludeOptions SegmentQuery_Include { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse).
        /// Specifying the name of a property of type Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CPFSegmentEstimate (CreateSegmentEstimate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse, NewCPFSegmentEstimateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SegmentQuery_Group != null)
            {
                context.SegmentQuery_Group = new List<Amazon.CustomerProfiles.Model.Group>(this.SegmentQuery_Group);
            }
            context.SegmentQuery_Include = this.SegmentQuery_Include;
            
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
            var request = new Amazon.CustomerProfiles.Model.CreateSegmentEstimateRequest();
            
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            
             // populate SegmentQuery
            var requestSegmentQueryIsNull = true;
            request.SegmentQuery = new Amazon.CustomerProfiles.Model.SegmentGroupStructure();
            List<Amazon.CustomerProfiles.Model.Group> requestSegmentQuery_segmentQuery_Group = null;
            if (cmdletContext.SegmentQuery_Group != null)
            {
                requestSegmentQuery_segmentQuery_Group = cmdletContext.SegmentQuery_Group;
            }
            if (requestSegmentQuery_segmentQuery_Group != null)
            {
                request.SegmentQuery.Groups = requestSegmentQuery_segmentQuery_Group;
                requestSegmentQueryIsNull = false;
            }
            Amazon.CustomerProfiles.IncludeOptions requestSegmentQuery_segmentQuery_Include = null;
            if (cmdletContext.SegmentQuery_Include != null)
            {
                requestSegmentQuery_segmentQuery_Include = cmdletContext.SegmentQuery_Include;
            }
            if (requestSegmentQuery_segmentQuery_Include != null)
            {
                request.SegmentQuery.Include = requestSegmentQuery_segmentQuery_Include;
                requestSegmentQueryIsNull = false;
            }
             // determine if request.SegmentQuery should be set to null
            if (requestSegmentQueryIsNull)
            {
                request.SegmentQuery = null;
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
        
        private Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse CallAWSServiceOperation(IAmazonCustomerProfiles client, Amazon.CustomerProfiles.Model.CreateSegmentEstimateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Customer Profiles", "CreateSegmentEstimate");
            try
            {
                return client.CreateSegmentEstimateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainName { get; set; }
            public List<Amazon.CustomerProfiles.Model.Group> SegmentQuery_Group { get; set; }
            public Amazon.CustomerProfiles.IncludeOptions SegmentQuery_Include { get; set; }
            public System.Func<Amazon.CustomerProfiles.Model.CreateSegmentEstimateResponse, NewCPFSegmentEstimateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
