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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Creates an EKS Anywhere subscription. When a subscription is created, it is a contract
    /// agreement for the length of the term specified in the request. Licenses that are used
    /// to validate support are provisioned in Amazon Web Services License Manager and the
    /// caller account is granted access to EKS Anywhere Curated Packages.
    /// </summary>
    [Cmdlet("New", "EKSEksAnywhereSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.EksAnywhereSubscription")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes CreateEksAnywhereSubscription API operation.", Operation = new[] {"CreateEksAnywhereSubscription"}, SelectReturnType = typeof(Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.EksAnywhereSubscription or Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse",
        "This cmdlet returns an Amazon.EKS.Model.EksAnywhereSubscription object.",
        "The service call response (type Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEKSEksAnywhereSubscriptionCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoRenew
        /// <summary>
        /// <para>
        /// <para>A boolean indicating whether the subscription auto renews at the end of the term.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoRenew { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Term_Duration
        /// <summary>
        /// <para>
        /// <para>The duration of the subscription term. Valid values are 12 and 36, indicating a 12
        /// month or 36 month subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Term_Duration { get; set; }
        #endregion
        
        #region Parameter LicenseQuantity
        /// <summary>
        /// <para>
        /// <para>The number of licenses to purchase with the subscription. Valid values are between
        /// 1 and 100. This value can't be changed after creating the subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LicenseQuantity { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The license type for all licenses in the subscription. Valid value is CLUSTER. With
        /// the CLUSTER license type, each license covers support for a single EKS Anywhere cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.EksAnywhereSubscriptionLicenseType")]
        public Amazon.EKS.EksAnywhereSubscriptionLicenseType LicenseType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The unique name for your subscription. It must be unique in your Amazon Web Services
        /// account in the Amazon Web Services Region you're creating the subscription in. The
        /// name can contain only alphanumeric characters (case-sensitive), hyphens, and underscores.
        /// It must start with an alphabetic character and can't be longer than 100 characters.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The metadata for a subscription to assist with categorization and organization. Each
        /// tag consists of a key and an optional value. Subscription tags don't propagate to
        /// any other resources associated with the subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Term_Unit
        /// <summary>
        /// <para>
        /// <para>The term unit of the subscription. Valid value is <c>MONTHS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.EksAnywhereSubscriptionTermUnit")]
        public Amazon.EKS.EksAnywhereSubscriptionTermUnit Term_Unit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Subscription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Subscription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EKSEksAnywhereSubscription (CreateEksAnywhereSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse, NewEKSEksAnywhereSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoRenew = this.AutoRenew;
            context.ClientRequestToken = this.ClientRequestToken;
            context.LicenseQuantity = this.LicenseQuantity;
            context.LicenseType = this.LicenseType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Term_Duration = this.Term_Duration;
            context.Term_Unit = this.Term_Unit;
            
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
            var request = new Amazon.EKS.Model.CreateEksAnywhereSubscriptionRequest();
            
            if (cmdletContext.AutoRenew != null)
            {
                request.AutoRenew = cmdletContext.AutoRenew.Value;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.LicenseQuantity != null)
            {
                request.LicenseQuantity = cmdletContext.LicenseQuantity.Value;
            }
            if (cmdletContext.LicenseType != null)
            {
                request.LicenseType = cmdletContext.LicenseType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Term
            var requestTermIsNull = true;
            request.Term = new Amazon.EKS.Model.EksAnywhereSubscriptionTerm();
            System.Int32? requestTerm_term_Duration = null;
            if (cmdletContext.Term_Duration != null)
            {
                requestTerm_term_Duration = cmdletContext.Term_Duration.Value;
            }
            if (requestTerm_term_Duration != null)
            {
                request.Term.Duration = requestTerm_term_Duration.Value;
                requestTermIsNull = false;
            }
            Amazon.EKS.EksAnywhereSubscriptionTermUnit requestTerm_term_Unit = null;
            if (cmdletContext.Term_Unit != null)
            {
                requestTerm_term_Unit = cmdletContext.Term_Unit;
            }
            if (requestTerm_term_Unit != null)
            {
                request.Term.Unit = requestTerm_term_Unit;
                requestTermIsNull = false;
            }
             // determine if request.Term should be set to null
            if (requestTermIsNull)
            {
                request.Term = null;
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
        
        private Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.CreateEksAnywhereSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "CreateEksAnywhereSubscription");
            try
            {
                #if DESKTOP
                return client.CreateEksAnywhereSubscription(request);
                #elif CORECLR
                return client.CreateEksAnywhereSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AutoRenew { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Int32? LicenseQuantity { get; set; }
            public Amazon.EKS.EksAnywhereSubscriptionLicenseType LicenseType { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? Term_Duration { get; set; }
            public Amazon.EKS.EksAnywhereSubscriptionTermUnit Term_Unit { get; set; }
            public System.Func<Amazon.EKS.Model.CreateEksAnywhereSubscriptionResponse, NewEKSEksAnywhereSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Subscription;
        }
        
    }
}
