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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a Lightsail subdomain, such as <c>mysite</c>, with the web address <c>mysite.amazonlightsail.com</c>.
    /// After the subdomain is created, use the <c>UpdateSubdomainAssociation</c> action to
    /// associate it with a Lightsail resource.
    /// 
    ///  
    /// <para>
    /// When you create a nested subdomain, such as <c>blog.mysite</c>, and you don't already
    /// have the top-level subdomain (<c>mysite</c>), Lightsail adds the top-level subdomain
    /// to your account in the <c>IMPLICIT</c> state.
    /// </para><para>
    /// You can have up to 30 subdomains in your account. Nested subdomains, subdomains in
    /// the <c>CREATE_FAILED</c> state, and deleted subdomains that other accounts can't create
    /// yet count toward this quota. Subdomains in the <c>IMPLICIT</c> state don't count toward
    /// this quota.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LSSubdomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.CreateSubdomainResponse")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateSubdomain API operation.", Operation = new[] {"CreateSubdomain"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateSubdomainResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.CreateSubdomainResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.CreateSubdomainResponse object containing multiple properties."
    )]
    public partial class NewLSSubdomainCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SubdomainName
        /// <summary>
        /// <para>
        /// <para>The subdomain to create (for example, <c>mysite</c> or <c>blog.mysite</c>).</para><para>A subdomain can contain one or two labels separated by a period (<c>.</c>). Each label
        /// must start and end with a lowercase letter or a number, and can contain only lowercase
        /// letters, numbers, and hyphens (<c>-</c>). The name can be up to 39 characters long,
        /// including periods. Labels that start with <c>xn--</c> aren't supported, and some names
        /// are reserved.</para><para>Specify only the subdomain. A web address, such as <c>mysite.amazonlightsail.com</c>,
        /// isn't accepted.</para><para>To create a nested subdomain, you must own the top-level subdomain or be able to create
        /// it.</para>
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
        public System.String SubdomainName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag keys and optional values to add to the subdomain during create.</para><para>Use the <c>TagResource</c> action to tag a resource after it's created.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Lightsail.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateSubdomainResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateSubdomainResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubdomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSSubdomain (CreateSubdomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateSubdomainResponse, NewLSSubdomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SubdomainName = this.SubdomainName;
            #if MODULAR
            if (this.SubdomainName == null && ParameterWasBound(nameof(this.SubdomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter SubdomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Lightsail.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Lightsail.Model.CreateSubdomainRequest();
            
            if (cmdletContext.SubdomainName != null)
            {
                request.SubdomainName = cmdletContext.SubdomainName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Lightsail.Model.CreateSubdomainResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateSubdomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateSubdomain");
            try
            {
                return client.CreateSubdomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SubdomainName { get; set; }
            public List<Amazon.Lightsail.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Lightsail.Model.CreateSubdomainResponse, NewLSSubdomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
