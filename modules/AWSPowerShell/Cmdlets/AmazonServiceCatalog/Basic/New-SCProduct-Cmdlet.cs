/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Requests a <i>Provision</i> of a specified product. A <i>ProvisionedProduct</i> is
    /// a resourced instance for a product. For example, provisioning a CloudFormation-template-backed
    /// product results in launching a CloudFormation stack and all the underlying resources
    /// that come with it. 
    /// 
    ///  
    /// <para>
    /// You can check the status of this request using the <a>DescribeRecord</a> operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SCProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceCatalog.Model.RecordDetail")]
    [AWSCmdlet("Invokes the ProvisionProduct operation against AWS Service Catalog.", Operation = new[] {"ProvisionProduct"})]
    [AWSCmdletOutput("Amazon.ServiceCatalog.Model.RecordDetail",
        "This cmdlet returns a RecordDetail object.",
        "The service call response (type Amazon.ServiceCatalog.Model.ProvisionProductResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSCProductCmdlet : AmazonServiceCatalogClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptLanguage
        /// <summary>
        /// <para>
        /// <para>The language code to use for this operation. Supported language codes are as follows:</para><para>"en" (English)</para><para>"jp" (Japanese)</para><para>"zh" (Chinese)</para><para>If no code is specified, "en" is used as the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AcceptLanguage { get; set; }
        #endregion
        
        #region Parameter NotificationArn
        /// <summary>
        /// <para>
        /// <para>Passed to CloudFormation. The SNS topic ARNs to which to publish stack-related events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NotificationArns")]
        public System.String[] NotificationArn { get; set; }
        #endregion
        
        #region Parameter PathId
        /// <summary>
        /// <para>
        /// <para>The identifier of the path for this product's provisioning. This value is optional
        /// if the product has a default path, and is required if there is more than one path
        /// for the specified product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PathId { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The identifier of the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter ProvisionedProductName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name to identify the ProvisionedProduct object. This value must be
        /// unique for the AWS account and cannot be updated after the product is provisioned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProvisionedProductName { get; set; }
        #endregion
        
        #region Parameter ProvisioningArtifactId
        /// <summary>
        /// <para>
        /// <para>The provisioning artifact identifier for this product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisioningArtifactId { get; set; }
        #endregion
        
        #region Parameter ProvisioningParameter
        /// <summary>
        /// <para>
        /// <para>Parameters specified by the administrator that are required for provisioning the product.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProvisioningParameters")]
        public Amazon.ServiceCatalog.Model.ProvisioningParameter[] ProvisioningParameter { get; set; }
        #endregion
        
        #region Parameter ProvisionToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token that uniquely identifies the provisioning request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProvisionToken { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to use as provisioning options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.ServiceCatalog.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProvisionedProductName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SCProduct (ProvisionProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AcceptLanguage = this.AcceptLanguage;
            if (this.NotificationArn != null)
            {
                context.NotificationArns = new List<System.String>(this.NotificationArn);
            }
            context.PathId = this.PathId;
            context.ProductId = this.ProductId;
            context.ProvisionedProductName = this.ProvisionedProductName;
            context.ProvisioningArtifactId = this.ProvisioningArtifactId;
            if (this.ProvisioningParameter != null)
            {
                context.ProvisioningParameters = new List<Amazon.ServiceCatalog.Model.ProvisioningParameter>(this.ProvisioningParameter);
            }
            context.ProvisionToken = this.ProvisionToken;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.ServiceCatalog.Model.Tag>(this.Tag);
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
            var request = new Amazon.ServiceCatalog.Model.ProvisionProductRequest();
            
            if (cmdletContext.AcceptLanguage != null)
            {
                request.AcceptLanguage = cmdletContext.AcceptLanguage;
            }
            if (cmdletContext.NotificationArns != null)
            {
                request.NotificationArns = cmdletContext.NotificationArns;
            }
            if (cmdletContext.PathId != null)
            {
                request.PathId = cmdletContext.PathId;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.ProvisionedProductName != null)
            {
                request.ProvisionedProductName = cmdletContext.ProvisionedProductName;
            }
            if (cmdletContext.ProvisioningArtifactId != null)
            {
                request.ProvisioningArtifactId = cmdletContext.ProvisioningArtifactId;
            }
            if (cmdletContext.ProvisioningParameters != null)
            {
                request.ProvisioningParameters = cmdletContext.ProvisioningParameters;
            }
            if (cmdletContext.ProvisionToken != null)
            {
                request.ProvisionToken = cmdletContext.ProvisionToken;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RecordDetail;
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
        
        private static Amazon.ServiceCatalog.Model.ProvisionProductResponse CallAWSServiceOperation(IAmazonServiceCatalog client, Amazon.ServiceCatalog.Model.ProvisionProductRequest request)
        {
            #if DESKTOP
            return client.ProvisionProduct(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ProvisionProductAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AcceptLanguage { get; set; }
            public List<System.String> NotificationArns { get; set; }
            public System.String PathId { get; set; }
            public System.String ProductId { get; set; }
            public System.String ProvisionedProductName { get; set; }
            public System.String ProvisioningArtifactId { get; set; }
            public List<Amazon.ServiceCatalog.Model.ProvisioningParameter> ProvisioningParameters { get; set; }
            public System.String ProvisionToken { get; set; }
            public List<Amazon.ServiceCatalog.Model.Tag> Tags { get; set; }
        }
        
    }
}
