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
using Amazon.CloudFront;
using Amazon.CloudFront.Model;

namespace Amazon.PowerShell.Cmdlets.CF
{
    /// <summary>
    /// Gets a list of aliases (also called CNAMEs or alternate domain names) that conflict
    /// or overlap with the provided alias, and the associated CloudFront distributions and
    /// Amazon Web Services accounts for each conflicting alias. In the returned list, the
    /// distribution and account IDs are partially hidden, which allows you to identify the
    /// distributions and accounts that you own, but helps to protect the information of ones
    /// that you don't own.
    /// 
    ///  
    /// <para>
    /// Use this operation to find aliases that are in use in CloudFront that conflict or
    /// overlap with the provided alias. For example, if you provide <c>www.example.com</c>
    /// as input, the returned list can include <c>www.example.com</c> and the overlapping
    /// wildcard alternate domain name (<c>*.example.com</c>), if they exist. If you provide
    /// <c>*.example.com</c> as input, the returned list can include <c>*.example.com</c>
    /// and any alternate domain names covered by that wildcard (for example, <c>www.example.com</c>,
    /// <c>test.example.com</c>, <c>dev.example.com</c>, and so on), if they exist.
    /// </para><para>
    /// To list conflicting aliases, you provide the alias to search and the ID of a distribution
    /// in your account that has an attached SSL/TLS certificate that includes the provided
    /// alias. For more information, including how to set up the distribution and certificate,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudFront/latest/DeveloperGuide/CNAMEs.html#alternate-domain-names-move">Moving
    /// an alternate domain name to a different distribution</a> in the <i>Amazon CloudFront
    /// Developer Guide</i>.
    /// </para><para>
    /// You can optionally specify the maximum number of items to receive in the response.
    /// If the total number of items in the list exceeds the maximum that you specify, or
    /// the default maximum, the response is paginated. To get the next page of items, send
    /// a subsequent request that specifies the <c>NextMarker</c> value from the current response
    /// as the <c>Marker</c> value in the subsequent request.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFConflictingAlias")]
    [OutputType("Amazon.CloudFront.Model.ConflictingAliasesList")]
    [AWSCmdlet("Calls the Amazon CloudFront ListConflictingAliases API operation.", Operation = new[] {"ListConflictingAliases"}, SelectReturnType = typeof(Amazon.CloudFront.Model.ListConflictingAliasesResponse))]
    [AWSCmdletOutput("Amazon.CloudFront.Model.ConflictingAliasesList or Amazon.CloudFront.Model.ListConflictingAliasesResponse",
        "This cmdlet returns an Amazon.CloudFront.Model.ConflictingAliasesList object.",
        "The service call response (type Amazon.CloudFront.Model.ListConflictingAliasesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFConflictingAliasCmdlet : AmazonCloudFrontClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The alias (also called a CNAME) to search for conflicting aliases.</para>
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
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter DistributionId
        /// <summary>
        /// <para>
        /// <para>The ID of a distribution in your account that has an attached SSL/TLS certificate
        /// that includes the provided alias.</para>
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
        public System.String DistributionId { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Use this field when paginating results to indicate where to begin in the list of conflicting
        /// aliases. The response includes conflicting aliases in the list that occur after the
        /// marker. To get the next page of the list, set this field's value to the value of <c>NextMarker</c>
        /// from the current page's response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>The maximum number of conflicting aliases that you want in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.Int32? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConflictingAliasesList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFront.Model.ListConflictingAliasesResponse).
        /// Specifying the name of a property of type Amazon.CloudFront.Model.ListConflictingAliasesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConflictingAliasesList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Alias parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Alias' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Alias' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CloudFront.Model.ListConflictingAliasesResponse, GetCFConflictingAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Alias;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Alias = this.Alias;
            #if MODULAR
            if (this.Alias == null && ParameterWasBound(nameof(this.Alias)))
            {
                WriteWarning("You are passing $null as a value for parameter Alias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DistributionId = this.DistributionId;
            #if MODULAR
            if (this.DistributionId == null && ParameterWasBound(nameof(this.DistributionId)))
            {
                WriteWarning("You are passing $null as a value for parameter DistributionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            
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
            var request = new Amazon.CloudFront.Model.ListConflictingAliasesRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.DistributionId != null)
            {
                request.DistributionId = cmdletContext.DistributionId;
            }
            if (cmdletContext.Marker != null)
            {
                request.Marker = cmdletContext.Marker;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem.Value;
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
        
        private Amazon.CloudFront.Model.ListConflictingAliasesResponse CallAWSServiceOperation(IAmazonCloudFront client, Amazon.CloudFront.Model.ListConflictingAliasesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudFront", "ListConflictingAliases");
            try
            {
                #if DESKTOP
                return client.ListConflictingAliases(request);
                #elif CORECLR
                return client.ListConflictingAliasesAsync(request).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.String DistributionId { get; set; }
            public System.String Marker { get; set; }
            public System.Int32? MaxItem { get; set; }
            public System.Func<Amazon.CloudFront.Model.ListConflictingAliasesResponse, GetCFConflictingAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConflictingAliasesList;
        }
        
    }
}
