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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates Amazon Quick Sight customizations. Currently, you can add a custom default
    /// theme by using the <c>CreateAccountCustomization</c> or <c>UpdateAccountCustomization</c>
    /// API operation. To further customize Amazon Quick Sight by removing Amazon Quick Sight
    /// sample assets and videos for all new users, see <a href="https://docs.aws.amazon.com/quicksight/latest/user/customizing-quicksight.html">Customizing
    /// Quick Sight</a> in the <i>Amazon Quick Sight User Guide.</i><para>
    /// You can create customizations for your Amazon Web Services account or, if you specify
    /// a namespace, for a Quick Sight namespace instead. Customizations that apply to a namespace
    /// always override customizations that apply to an Amazon Web Services account. To find
    /// out which customizations apply, use the <c>DescribeAccountCustomization</c> API operation.
    /// </para><para>
    /// Before you use the <c>CreateAccountCustomization</c> API operation to add a theme
    /// as the namespace default, make sure that you first share the theme with the namespace.
    /// If you don't share it with the namespace, the theme isn't visible to your users even
    /// if you make it the default theme. To check if the theme is shared, view the current
    /// permissions by using the <c><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_DescribeThemePermissions.html">DescribeThemePermissions</a></c> API operation. To share the theme, grant permissions by using the <c><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_UpdateThemePermissions.html">UpdateThemePermissions</a></c> API operation. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "QSAccountCustomization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.CreateAccountCustomizationResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight CreateAccountCustomization API operation.", Operation = new[] {"CreateAccountCustomization"}, SelectReturnType = typeof(Amazon.QuickSight.Model.CreateAccountCustomizationResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.CreateAccountCustomizationResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.CreateAccountCustomizationResponse object containing multiple properties."
    )]
    public partial class NewQSAccountCustomizationCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that you want to customize Quick Sight
        /// for.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter AccountCustomization_DefaultEmailCustomizationTemplate
        /// <summary>
        /// <para>
        /// <para>The default email customization template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountCustomization_DefaultEmailCustomizationTemplate { get; set; }
        #endregion
        
        #region Parameter AccountCustomization_DefaultTheme
        /// <summary>
        /// <para>
        /// <para>The default theme for this Quick Sight subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountCustomization_DefaultTheme { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The Quick Sight namespace that you want to add customizations to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of the tags that you want to attach to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.QuickSight.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.CreateAccountCustomizationResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.CreateAccountCustomizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsAccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QSAccountCustomization (CreateAccountCustomization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.CreateAccountCustomizationResponse, NewQSAccountCustomizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountCustomization_DefaultEmailCustomizationTemplate = this.AccountCustomization_DefaultEmailCustomizationTemplate;
            context.AccountCustomization_DefaultTheme = this.AccountCustomization_DefaultTheme;
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.QuickSight.Model.Tag>(this.Tag);
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
            var request = new Amazon.QuickSight.Model.CreateAccountCustomizationRequest();
            
            
             // populate AccountCustomization
            var requestAccountCustomizationIsNull = true;
            request.AccountCustomization = new Amazon.QuickSight.Model.AccountCustomization();
            System.String requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate = null;
            if (cmdletContext.AccountCustomization_DefaultEmailCustomizationTemplate != null)
            {
                requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate = cmdletContext.AccountCustomization_DefaultEmailCustomizationTemplate;
            }
            if (requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate != null)
            {
                request.AccountCustomization.DefaultEmailCustomizationTemplate = requestAccountCustomization_accountCustomization_DefaultEmailCustomizationTemplate;
                requestAccountCustomizationIsNull = false;
            }
            System.String requestAccountCustomization_accountCustomization_DefaultTheme = null;
            if (cmdletContext.AccountCustomization_DefaultTheme != null)
            {
                requestAccountCustomization_accountCustomization_DefaultTheme = cmdletContext.AccountCustomization_DefaultTheme;
            }
            if (requestAccountCustomization_accountCustomization_DefaultTheme != null)
            {
                request.AccountCustomization.DefaultTheme = requestAccountCustomization_accountCustomization_DefaultTheme;
                requestAccountCustomizationIsNull = false;
            }
             // determine if request.AccountCustomization should be set to null
            if (requestAccountCustomizationIsNull)
            {
                request.AccountCustomization = null;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
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
        
        private Amazon.QuickSight.Model.CreateAccountCustomizationResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.CreateAccountCustomizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "CreateAccountCustomization");
            try
            {
                #if DESKTOP
                return client.CreateAccountCustomization(request);
                #elif CORECLR
                return client.CreateAccountCustomizationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountCustomization_DefaultEmailCustomizationTemplate { get; set; }
            public System.String AccountCustomization_DefaultTheme { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String Namespace { get; set; }
            public List<Amazon.QuickSight.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.QuickSight.Model.CreateAccountCustomizationResponse, NewQSAccountCustomizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
