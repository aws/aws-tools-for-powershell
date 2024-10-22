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
using Amazon.CodeCatalyst;
using Amazon.CodeCatalyst.Model;

namespace Amazon.PowerShell.Cmdlets.CCAT
{
    /// <summary>
    /// Retrieves a list of branches in a specified source repository.
    /// </summary>
    [Cmdlet("Get", "CCATSourceRepositoryBranchList")]
    [OutputType("Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesItem")]
    [AWSCmdlet("Calls the AWS CodeCatalyst ListSourceRepositoryBranches API operation.", Operation = new[] {"ListSourceRepositoryBranches"}, SelectReturnType = typeof(Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse))]
    [AWSCmdletOutput("Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesItem or Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse",
        "This cmdlet returns a collection of Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesItem objects.",
        "The service call response (type Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCCATSourceRepositoryBranchListCmdlet : AmazonCodeCatalystClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project in the space.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter SourceRepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the source repository.</para>
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
        public System.String SourceRepositoryName { get; set; }
        #endregion
        
        #region Parameter SpaceName
        /// <summary>
        /// <para>
        /// <para>The name of the space.</para>
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
        public System.String SpaceName { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to show in a single call to this API. If the number
        /// of results is larger than the number you specified, the response will include a <c>NextToken</c>
        /// element, which you can use to obtain additional results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token returned from a call to this API to indicate the next batch of results to
        /// return, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse).
        /// Specifying the name of a property of type Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._ExecuteWithAnonymousCredentials = true;
            this._AWSSignerType = "bearer";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse, GetCCATSourceRepositoryBranchListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceRepositoryName = this.SourceRepositoryName;
            #if MODULAR
            if (this.SourceRepositoryName == null && ParameterWasBound(nameof(this.SourceRepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceRepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SpaceName = this.SpaceName;
            #if MODULAR
            if (this.SpaceName == null && ParameterWasBound(nameof(this.SpaceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            if (cmdletContext.SourceRepositoryName != null)
            {
                request.SourceRepositoryName = cmdletContext.SourceRepositoryName;
            }
            if (cmdletContext.SpaceName != null)
            {
                request.SpaceName = cmdletContext.SpaceName;
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
        
        private Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse CallAWSServiceOperation(IAmazonCodeCatalyst client, Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeCatalyst", "ListSourceRepositoryBranches");
            try
            {
                #if DESKTOP
                return client.ListSourceRepositoryBranches(request);
                #elif CORECLR
                return client.ListSourceRepositoryBranchesAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String ProjectName { get; set; }
            public System.String SourceRepositoryName { get; set; }
            public System.String SpaceName { get; set; }
            public System.Func<Amazon.CodeCatalyst.Model.ListSourceRepositoryBranchesResponse, GetCCATSourceRepositoryBranchListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
