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
using Amazon.MigrationHubRefactorSpaces;
using Amazon.MigrationHubRefactorSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.MHRS
{
    /// <summary>
    /// Lists all Amazon Web Services Migration Hub Refactor Spaces service virtual private
    /// clouds (VPCs) that are part of the environment.
    /// </summary>
    [Cmdlet("Get", "MHRSEnvironmentVpcList")]
    [OutputType("Amazon.MigrationHubRefactorSpaces.Model.EnvironmentVpc")]
    [AWSCmdlet("Calls the AWS Migration Hub Refactor Spaces ListEnvironmentVpcs API operation.", Operation = new[] {"ListEnvironmentVpcs"}, SelectReturnType = typeof(Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse))]
    [AWSCmdletOutput("Amazon.MigrationHubRefactorSpaces.Model.EnvironmentVpc or Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse",
        "This cmdlet returns a collection of Amazon.MigrationHubRefactorSpaces.Model.EnvironmentVpc objects.",
        "The service call response (type Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMHRSEnvironmentVpcListCmdlet : AmazonMigrationHubRefactorSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EnvironmentIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the environment. </para>
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
        public System.String EnvironmentIdentifier { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EnvironmentVpcList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse).
        /// Specifying the name of a property of type Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EnvironmentVpcList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EnvironmentIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EnvironmentIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EnvironmentIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse, GetMHRSEnvironmentVpcListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EnvironmentIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EnvironmentIdentifier = this.EnvironmentIdentifier;
            #if MODULAR
            if (this.EnvironmentIdentifier == null && ParameterWasBound(nameof(this.EnvironmentIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsRequest();
            
            if (cmdletContext.EnvironmentIdentifier != null)
            {
                request.EnvironmentIdentifier = cmdletContext.EnvironmentIdentifier;
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
        
        private Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse CallAWSServiceOperation(IAmazonMigrationHubRefactorSpaces client, Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub Refactor Spaces", "ListEnvironmentVpcs");
            try
            {
                #if DESKTOP
                return client.ListEnvironmentVpcs(request);
                #elif CORECLR
                return client.ListEnvironmentVpcsAsync(request).GetAwaiter().GetResult();
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
            public System.String EnvironmentIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.MigrationHubRefactorSpaces.Model.ListEnvironmentVpcsResponse, GetMHRSEnvironmentVpcListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EnvironmentVpcList;
        }
        
    }
}
