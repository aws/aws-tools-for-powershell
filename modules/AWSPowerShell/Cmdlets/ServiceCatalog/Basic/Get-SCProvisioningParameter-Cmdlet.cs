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
using Amazon.ServiceCatalog;
using Amazon.ServiceCatalog.Model;

namespace Amazon.PowerShell.Cmdlets.SC
{
    /// <summary>
    /// Gets information about the configuration required to provision the specified product
    /// using the specified provisioning artifact.
    /// 
    ///  
    /// <para>
    /// If the output contains a TagOption key with an empty list of values, there is a TagOption
    /// conflict for that key. The end user cannot take action to fix the conflict, and launch
    /// is not blocked. In subsequent calls to <a>ProvisionProduct</a>, do not include conflicted
    /// TagOption keys as tags, or this causes the error "Parameter validation failed: Missing
    /// required parameter in Tags[<i>N</i>]:<i>Value</i>". Tag the provisioned product with
    /// the value <code>sc-tagoption-conflict-portfolioId-productId</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SCProvisioningParameter")]
    [OutputType("Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog DescribeProvisioningParameters API operation.", Operation = new[] {"DescribeProvisioningParameters"}, SelectReturnType = typeof(Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse))]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse",
        "This cmdlet returns an Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSCProvisioningParameterCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code.</para><ul><li><para><code>en</code> - English (default)</para></li><li><para><code>jp</code> - Japanese</para></li><li><para><code>zh</code> - Chinese</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter PathId
        /// <summary>
        /// <para>
        /// <para>The path identifier of the product. This value is optional if the product has a default
        /// path, and required if the product has more than one path. To list the paths for a
        /// product, use <a>ListLaunchPaths</a>. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PathId { get; set; }
        #endregion
        
        #region Parameter PathName
        /// <summary>
        /// <para>
        /// <para>The name of the path. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PathName { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The product identifier. You must provide the product name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter ProductName
        /// <summary>
        /// <para>
        /// <para>The name of the product. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProductName { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the provisioning artifact. You must provide the name or ID, but
        /// not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactName
        /// <summary>
        /// <para>
        /// <para>The name of the provisioning artifact. You must provide the name or ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProvisioningArtifactName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse).
        /// Specifying the name of a property of type Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProductId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProductId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProductId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse, GetSCProvisioningParameterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProductId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptLanguage = this.AcceptLanguage;
            context.PathId = this.PathId;
            context.PathName = this.PathName;
            context.ProductId = this.ProductId;
            context.ProductName = this.ProductName;
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            context.ProvisioningArtifactName = this.ProvisioningArtifactName;
            
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
            var request = new Amazon.ServiceCatalog.Model.DescribeProvisioningParametersRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.PathId != null)
            {
                request.PathId = cmdletContext.PathId;
            }
            if (cmdletContext.PathName != null)
            {
                request.PathName = cmdletContext.PathName;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.ProductName != null)
            {
                request.ProductName = cmdletContext.ProductName;
            }
            if (cmdletContext.ProvisioningArtifactId != null)
            {
                request.ProvisioningArtifactId = cmdletContext.ProvisioningArtifactId;
            }
            if (cmdletContext.ProvisioningArtifactName != null)
            {
                request.ProvisioningArtifactName = cmdletContext.ProvisioningArtifactName;
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
        
        private Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.DescribeProvisioningParametersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog", "DescribeProvisioningParameters");
            try
            {
                #if DESKTOP
                return client.DescribeProvisioningParameters(request);
                #elif CORECLR
                return client.DescribeProvisioningParametersAsync(request).GetAwaiter().GetResult();
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
            public System.String AcceptLanguage { get; set; }
            public System.String PathId { get; set; }
            public System.String PathName { get; set; }
            public System.String ProductId { get; set; }
            public System.String ProductName { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
            public System.String ProvisioningArtifactName { get; set; }
            public System.Func<Amazon.ServiceCatalog.Model.DescribeProvisioningParametersResponse, GetSCProvisioningParameterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
